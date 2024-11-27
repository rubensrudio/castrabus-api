using CastraBus.Common.Domain.Concret.Enuns;
using System.Runtime.Serialization;

namespace CastraBus.Common.Domain.Generic
{
    [DataContract]
    public class DataResult
    {
        [DataMember]
        public ListResultTypeEnum ResultType { get; set; }

        [DataMember]
        public object Result { get; set; }

        [DataMember]
        public object Paginate { get; set; }

        [DataMember]
        public static object ListResultTypeEnum { get; set; }

        public DataResult()
        {
            //default constructor
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="resultType"></param>
        /// <param name="result"></param>
        public DataResult(ListResultTypeEnum resultType, object result)
        {
            ResultType = resultType;
            Result = result;
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="resultType"></param>
        /// <param name="result"></param>
        public DataResult(ListResultTypeEnum resultType, string result)
        {
            ResultType = resultType;
            Result = result;
        }


        [DataMember]
        public bool HasError
        {
            get
            {
                return ResultType == Concret.Enuns.ListResultTypeEnum.Error;
            }
        }
    }
}
