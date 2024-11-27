using CastraBus.Application.Entities.ViewModel;
using CastraBus.Common.Singleton;
using Microsoft.Extensions.Configuration;
using NATS.Client;
using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;
using Serilog;
using System.Text.Json;

namespace CastraBus.Application.Services.Concret
{
    public class NatsServiceAsync
    {
        private readonly ILogger logger;
        private readonly NatsOptions natsOptions;
        private readonly IConfiguration configuration;

        public NatsServiceAsync(IConfiguration configuration, ILogger logger)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.natsOptions = this.configuration.GetSection("NatsOptions").Get<NatsOptions>();
        }

        public bool CheckIntegracao()
        {
            return this.natsOptions.Integracao;
        }

        public bool CheckHealth()
        {
            try
            {
                if (string.IsNullOrEmpty(this.natsOptions.Url))
                {
                    this.logger.Information($"Não foi definido a Url de conexão com o Nats");
                    return false;
                }

                var op = ConnectionFactory.GetDefaultOptions();
                op.Url = this.natsOptions.Url;

                using (var conn = new ConnectionFactory().CreateConnection(op))
                {
                    return conn.State == ConnState.CONNECTED;
                }
            }
            catch (Exception ex)
            {
                this.logger.Error($"Error: {ex.Message}", ex);
                throw ex;
            }
        }

        /// <summary>
        /// Método para Consumir uma mensagem no Nats
        /// </summary>
        /// <param name="messenger">Objeto para Consumer do Nats</param>
        /// <returns>Retorna a mensagem consumida pelo Nats</returns>
        public async Task<string> Consumer(MessengerVm messenger)
        {
            var timeout = TimeSpan.FromSeconds(5);
            String MensagemRetorno = string.Empty;

            try
            {
                var opts = NatsOpts.Default with
                {
                    AuthOpts = NatsAuthOpts.Default with
                    {
                        Username = this.natsOptions.UserName,
                        Password = this.natsOptions.Password
                    },
                    Url = this.natsOptions.Url //"nats://192.168.1.250:4222"
                };

                await using var nats = new NatsConnection(opts);
                var js = new NatsJSContext(nats);

                // Create a consumer to receive the messages
                var consumer = await js.CreateOrUpdateConsumerAsync(messenger.Queue, new ConsumerConfig(messenger.Queue));

                Console.WriteLine($"Aguardando mensagens de {opts.Url} do topico {messenger.Queue}");

                await foreach (var jsMsg in consumer.ConsumeAsync<string>().WithCancellation(new CancellationTokenSource(timeout).Token))
                {
                    if (jsMsg.Data is not null)
                    {
                        string json = jsMsg.Data;
                        MessengerVm msg = JsonSerializer.Deserialize<MessengerVm>(json);

                        if (msg is not null)
                        {
                            MensagemRetorno = msg.Message;

                            Console.WriteLine($"Processed: {msg.CreatedAt} --> {msg.Message}");
                            Console.WriteLine($"Processed: {jsMsg.Data}");
                            await jsMsg.AckAsync();
                        }
                    }
                }

                return MensagemRetorno;
            }
            catch (Exception ex)
            {
                this.logger.Error(string.Format("Erro ao Consumir Mensagem {0}", ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// Método para Produzir uma mensagem num topico do Nats
        /// </summary>
        /// <param name="messenger">Objeto de Producao de Mensagem no Nats</param>
        public async Task Producer(MessengerVm messenger)
        {
            try
            {
                Task.Run(async () =>
                {
                    try
                    {
                        var opts = NatsOpts.Default with
                        {
                            AuthOpts = NatsAuthOpts.Default with
                            {
                                Username = this.natsOptions.UserName,
                                Password = this.natsOptions.Password
                            },
                            Url = this.natsOptions.Url //"nats://192.168.1.250:4222"
                        };

                        await using var nats = new NatsConnection(opts);
                        var js = new NatsJSContext(nats);

                        // Create a stream to store the messages
                        // 180 dias de retenção
                        // 5Gb o tamanho máximo, quando ultrapassado as mensagens mais antigas serão removidas automaticamente.
                        await js.CreateStreamAsync(new StreamConfig(name: messenger.Queue, subjects: new[] { $"{messenger.Queue}.*" }) { MaxAge = TimeSpan.FromDays(180), MaxBytes = 5000000000 });

                        string text = System.Text.Json.JsonSerializer.Serialize(messenger);

                        // Publish a message to the stream. The message will be stored in the stream
                        // because the published subject matches one of the the stream's subjects.
                        var ack = await js.PublishAsync(subject: $"{messenger.Queue}.new", data: text);
                        ack.EnsureSuccess();

                        Console.WriteLine($"[ProducerMessage] Nats position: {ack.Seq}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message, ex);
                        //TODO: adicionar erro para gogole grupo 
                    }
                });
            }
            catch (Exception ex)
            {
                this.logger.Error(string.Format("Erro ao Produzir a Mensagem {0}", ex.Message));
                throw ex;
            }
        }
    }
}
