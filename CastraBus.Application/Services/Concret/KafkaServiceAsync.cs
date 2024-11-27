using CastraBus.Application.Entities.ViewModel;
using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Common.Domain.Generic;
using CastraBus.Common.Singleton;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class KafkaServiceAsync
    {
        private readonly ILogger logger;
        private readonly KafkaOptions kafkaOptions;
        private readonly IConfiguration configuration;

        public KafkaServiceAsync(IConfiguration configuration, ILogger logger)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.kafkaOptions = this.configuration.GetSection("KafkaOptions").Get<KafkaOptions>();
        }

        /// <summary>
        /// Método para Consumir um Tópico no Kafka
        /// </summary>
        /// <param name="messenger">Objeto para Consumer do Kafka</param>
        /// <returns>Retorna a mensagem consumida pelo Kafka</returns>
        public Task<string> Consumer(MessengerVm messenger)
        {
            String MensagemRetorno = string.Empty;
            Message<Ignore, string> msg = null;

            try
            {
                return Task.Run(() =>
                {
                    var config = new ConsumerConfig
                    {
                        BootstrapServers = this.kafkaOptions.IpKafka,
                        GroupId = messenger.Queue,
                        EnableAutoCommit = this.kafkaOptions.CommitMessage,
                        StatisticsIntervalMs = this.kafkaOptions.StatisticsInterval,
                        SessionTimeoutMs = this.kafkaOptions.TimeOut,
                        AutoOffsetReset = AutoOffsetReset.Latest
                    };

                    using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                    {
                        consumer.Subscribe(messenger.Queue);
                        var c = consumer.Consume(TimeSpan.FromSeconds(100));
                        MensagemRetorno = c.Value;
                    }

                    return MensagemRetorno;
                });
            }
            catch (Exception ex)
            {
                this.logger.Error(string.Format("Erro ao Consumir Mensagem {0}", ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// Método para Produzir uma mensagem num topico do Kafka
        /// </summary>
        /// <param name="messenger">Objeto de Producao de Mensagem no Kafka</param>
        public async Task<DataResult> Producer(MessengerVm messenger)
        {
            try
            {
                var dataResult = new DataResult();
                var config = new ProducerConfig
                {
                    BootstrapServers = this.kafkaOptions.IpKafka,
                    MessageMaxBytes = Convert.ToInt32(this.kafkaOptions.MessageMaxBytes)
                };

                using (var producer = new ProducerBuilder<string, string>(config).Build())
                {
                    try
                    {
                        var c = new Message<string, string> { Key = null, Value = messenger.Message };
                        var deliveryReport = await producer.ProduceAsync(messenger.Queue, c);
                        this.logger.Information(string.Format("Retorno da Producao da Mensagem Value: {0}", deliveryReport.Value));

                        dataResult = new DataResult
                        {
                            ResultType = ListResultTypeEnum.Success,
                            Result = deliveryReport.Value,
                            Paginate = null
                        };
                    }
                    catch (ProduceException<Null, string> ex)
                    {
                        dataResult = new DataResult
                        {
                            ResultType = ListResultTypeEnum.Error,
                            Result = ex.Error.Reason,
                            Paginate = null
                        };
                    }

                    return dataResult;
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(string.Format("Erro ao Produzir a Mensagem {0}", ex.Message));
                throw ex;
            }
        }
    }
}
