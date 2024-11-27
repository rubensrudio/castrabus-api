namespace CastraBus.Application.Entities.ViewModel
{
    public class ReceitaPdfVm
    {
        public String NomeAnimal { get; set; }
        public String PesoAnimal { get; set; }
        public List<ReceitaVm> Receitas { get; set; }
        public String Ob1 { get; set; }
        public String Ob2 { get; set; }
        public String Ob3 { get; set; }
        public String Dia { get; set; }
        public String Mes { get; set; }
        public String Ano { get; set; }
        public String NomeVeterinario { get; set; }
        public String TelefoneZap { get; set; }
        public String TelefoneEscritorio { get; set; }
    }
}
