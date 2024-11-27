using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Vacina")]
    public class VacinaEntity : BaseEntity
    {
        [Column("data_vacinacao")]
        public String DataVacinacao { get; set; }

        [Column("data_proxima_vacinacao")]
        public String DataProximaVacinacao { get; set; }

        [Column("observacao")]
        [StringLength(4000)]
        public String Observacao { get; set; }

        [Column("Animal_Id")]
        public Int64 AnimalId { get; set; }

        public AnimalEntity Animal { get; set; }

        [Column("TipoVacina_Id")]
        public Int64 TipoVacinaId { get; set; }

        public TipoVacinaEntity TipoVacina { get; set; }
    }
}
