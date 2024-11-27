using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Arquivo")]
    public class ArquivoEntity : BaseEntity
    {
        public List<PessoaEntity>? Pessoas { get; set; } = [];
        public List<AnimalEntity>? Animals { get; set; } = [];
    }
}
