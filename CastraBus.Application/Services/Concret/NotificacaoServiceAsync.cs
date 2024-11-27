using CastraBus.Application.Entities.ViewModel;
using Serilog;
using System.Text.Json;

namespace CastraBus.Application.Services.Concret
{
    public class NotificacaoServiceAsync
    {
        private readonly ILogger _logger;
        private readonly NatsServiceAsync natsService;

        public NotificacaoServiceAsync(NatsServiceAsync natsService, ILogger logger)
        {
            this._logger = logger;
            this.natsService = natsService;
        }

        public async Task SendNotificacaoEmail(AgendamentoVm agendamento)
        {
            try
            {
                if (!this.natsService.CheckIntegracao())
                {
                    this._logger.Information($"Sua integração não está ativa, ajuste o arquivo de configuração e verifique se o serviço do nats está ativo");
                }
                else
                {
                    this._logger.Information($"Verificando se o Serviço Nats está no para realização do envio de mensagens de email");
                    if (this.natsService.CheckHealth())
                    {
                        MessengerVm messenger = new MessengerVm()
                        {
                            Type = "",
                            Queue = "envio-email",
                            Message = JsonSerializer.Serialize(agendamento),
                            CreatedAt = DateTime.Now.ToString()
                        };

                        await this.natsService.Producer(messenger);
                    }
                    else
                    {
                        this._logger.Information($"Serviço está fora do ar, desligado ou não foi definido a sua conexão");
                    }
                }
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error: {ex.Message}", ex);
                throw ex;
            }
        }

        public async Task SendNotificacaoWhatsapp(AgendamentoVm agendamento)
        {
            try
            {
                if (!this.natsService.CheckIntegracao())
                {
                    this._logger.Information($"Sua integração não está ativa, ajuste o arquivo de configuração e verifique se o serviço do nats está ativo");
                }
                else
                {
                    this._logger.Information($"Verificando se o Serviço Nats está no para realização do envio de mensagens do whatsapp");
                    if (this.natsService.CheckHealth())
                    {
                        MessengerVm messenger = new MessengerVm()
                        {
                            Type = "",
                            Queue = "envio-whatsapp",
                            Message = JsonSerializer.Serialize(agendamento),
                            CreatedAt = DateTime.Now.ToString()
                        };

                        await this.natsService.Producer(messenger);
                    }
                    else
                    {
                        this._logger.Information($"Serviço está fora do ar, desligado ou não foi definido a sua conexão");
                    }
                }
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error: {ex.Message}", ex);
                throw ex;
            }
        }
    }
}
