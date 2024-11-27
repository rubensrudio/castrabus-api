using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CastraBus.Infra.Data.Entities.Generic
{
    [DataContract]
    public abstract class BaseEntity
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Int64 Id { get; set; }
    }
}
