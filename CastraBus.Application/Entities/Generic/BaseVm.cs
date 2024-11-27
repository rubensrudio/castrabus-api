using System.Runtime.Serialization;

namespace CastraBus.Application.Entities.Generic
{
    [DataContract]
    public abstract class BaseVm
    {
        [DataMember]
        public virtual Int64 Id { get; set; }
    }
}
