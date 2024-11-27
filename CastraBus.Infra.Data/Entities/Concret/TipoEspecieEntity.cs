using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("TipoEspecie")]
    public class TipoEspecieEntity : BaseEntity
    {
        [Column("nome")]
        [StringLength(50)]
        public required String Nome { get; set; }

        public ICollection<AnimalEntity> Animals { get; set; } = new HashSet<AnimalEntity>();

        public ICollection<MedicacaoEntity> Medicacaos { get; set; } = new HashSet<MedicacaoEntity>();

        public ICollection<FaixaHorarioEntity> FaixaHorarios { get; set; } = new HashSet<FaixaHorarioEntity>();
    }
}
