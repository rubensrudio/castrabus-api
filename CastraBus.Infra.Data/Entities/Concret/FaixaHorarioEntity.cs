using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("FaixaHorario")]
    public class FaixaHorarioEntity : BaseEntity
    {
        [Column("horario_inicio")]
        public String HorarioInicio { get; set; }

        [Column("horario_fim")]
        public String HorarioFim { get; set; }

        [Column("tipoEspecie_id")]
        public Int64 TipoEspecieId { get; set; }

        [Column("campanha_id")]
        public Int64 CampanhaId { get; set; }

        public CampanhaEntity Campanha { get; set; }
        public TipoEspecieEntity TipoEspecie { get; set; }
    }
}
