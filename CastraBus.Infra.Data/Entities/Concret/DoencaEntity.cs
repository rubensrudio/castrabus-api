using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Doenca")]
    public class DoencaEntity : BaseEntity
    {
        [Column("diagnostico")]
        [StringLength(4000)]
        public String Diagnostico { get; set; }

        [Column("tratamento")]
        [StringLength(4000)]
        public String Tratamento { get; set; }

        [Column("Animal_Id")]
        public Int64 AnimalId { get; set; }

        public AnimalEntity Animal { get; set; }

        [Column("TipoDoenca_Id")]
        public Int64 TipoDoencaId { get; set; }

        public TipoDoencaEntity TipoDoenca { get; set; }
    }
}
