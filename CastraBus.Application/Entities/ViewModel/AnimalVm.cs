using AutoMapper;
using CastraBus.Application.Entities.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Entities.ViewModel
{
    public class AnimalVm : BaseVm
    {
        [StringLength(50)]
        public String Nome { get; set; }

        public string? Ano { get; set; }

        public string? Meses { get; set; }

        public Double Peso { get; set; }

        [StringLength(50)]
        public String? Chip { get; set; }

        [StringLength(50)]
        public String? Raca { get; set; }

        [StringLength(50)]
        public String? Pelagem { get; set; }

        public Int64 SexoId { get; set; }

        public TipoSexoVm? Sexo { get; set; }

        public Int64 EspecieId { get; set; }

        public TipoEspecieVm? Especie { get; set; }

        public Int64 PessoaId { get; set; }

        public PessoaVm? Pessoa { get; set; }

        public List<TipoVacinaVm>? Vacinas { get; set; } = [];

        public List<TipoDoencaVm>? Doencas { get; set; } = [];

        public List<ArquivoVm>? Arquivos { get; set; } = [];

        public AnimalVm() { }

        public AnimalVm(AnimalEntity entity)
        {
            this.Nome = entity.Nome;
            this.Ano = entity.Ano;
            this.Meses = entity.Meses;
            this.Peso = entity.Peso;
            this.Chip = entity.Chip;
            this.Raca = entity.Raca;
            this.SexoId = entity.SexoId;
            this.EspecieId = entity.EspecieId;
            this.PessoaId = entity.PessoaId;
        }
    }
}
