using System.Runtime.Serialization;

namespace CastraBus.Common.Domain.Concret.Enuns
{
    [DataContract]
    public enum ListResultTypeEnum
    {
        [DataMember]
        Error,
        [DataMember]
        Success
    }
}
