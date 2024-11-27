using CastraBus.Application.Entities.ViewModel;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CastraBus.Application.Services.Concret
{
    public class PdfServiceAsync
    {
        private readonly IConverter converter;
        private readonly IConfiguration configuration;
        private readonly IHostEnvironment hostEnvironment;

        public PdfServiceAsync(IConverter converter
                             , IConfiguration configuration
                             , IHostEnvironment hostEnvironments)
        {
            this.converter = converter;
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironments;
        }

        public byte[] GetPdfReceita(ReceitaPdfVm receitaPdf)
        {
            try
            {
                var html = GetHtmlReceita(receitaPdf);

                var pdfDocument = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Landscape,
                        PaperSize = PaperKind.A4,
                        Margins = new MarginSettings { Top = 5, Bottom = 5, Left = 5, Right = 5 },
                    },
                    Objects = {
                        new ObjectSettings()
                        {
                            PagesCount = true,
                            HtmlContent = html,
                            WebSettings = { DefaultEncoding = "utf-8" },
                            FooterSettings = { Center = "Página [page] de [toPage]", FontSize = 9 }
                        }
                    }
                };

                var pdfBytes = this.converter.Convert(pdfDocument);

                return pdfBytes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetHtmlReceita(ReceitaPdfVm receitaPdf)
        {
            if (Equals(receitaPdf, null))
            {
                receitaPdf = ObjetoTest();
            }

            string Medicamentos = string.Empty;
            string receitaPath = Path.Combine(this.hostEnvironment.ContentRootPath, "Config", "Resources", "template", "receita.html");
            string html = File.ReadAllText(receitaPath);

            string logoPath = Path.Combine(this.hostEnvironment.ContentRootPath, "Config", "Resources", "images", "logo.png");
            byte[] imageBytes = File.ReadAllBytes(logoPath);
            string base64String = Convert.ToBase64String(imageBytes);

            if (!Equals(receitaPdf, null))
            {
                html = html.Replace("{{ImagemBase64}}", base64String);
                html = html.Replace("{{NomeAnimal}}", receitaPdf.NomeAnimal);
                html = html.Replace("{{PesoAnimal}}", receitaPdf.PesoAnimal);

                if (!Equals(receitaPdf.Receitas, null))
                {
                    foreach (var item in receitaPdf.Receitas)
                    {

                    }

                    if (!string.IsNullOrEmpty(Medicamentos))
                    {
                        html = html.Replace("{{Medicamentos}}", Medicamentos);
                    }
                }
                else
                {
                    html = html.Replace("{{Medicamentos}}", GetMedicacao());
                }

                html = html.Replace("{{Ob1}}", receitaPdf.Ob1);
                html = html.Replace("{{Ob2}}", receitaPdf.Ob2);
                html = html.Replace("{{Ob3}}", receitaPdf.Ob3);
                html = html.Replace("{{Dia}}", receitaPdf.Dia);
                html = html.Replace("{{Mes}}", receitaPdf.Mes);
                html = html.Replace("{{Ano}}", receitaPdf.Ano);
                html = html.Replace("{{NomeVeterinario}}", receitaPdf.NomeVeterinario);
                html = html.Replace("{{TelefoneZap}}", receitaPdf.TelefoneZap);
                html = html.Replace("{{TelefoneEscritorio}}", receitaPdf.TelefoneEscritorio);
            }
            
            return html;
        }

        private ReceitaPdfVm ObjetoTest()
        {
            return new ReceitaPdfVm()
            {
                NomeAnimal = "Laica",
                PesoAnimal = "30",
                Ob1 = "1",
                Ob2 = "2",
                Ob3 = "3",
                Dia = DateTime.Now.Day.ToString(),
                Mes = DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("pt-BR")),
                Ano = DateTime.Now.Year.ToString(),
                NomeVeterinario = "Francisca Clara Stefany Oliveira",
                TelefoneZap = "2198253-7043",
                TelefoneEscritorio = "2198253-7043"
            };
        }

        private string GetMedicacao()
        {
            return "<li>Amoxilina</li><li>Amoxilina</li><li>Amoxilina</li><li>Amoxilina</li>";
        }
    }
}
