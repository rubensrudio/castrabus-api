using CastraBus.Common.Domain.Concret.Enuns;

namespace CastraBus.Common.Util
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public RequestExecutionEnum Status { get; set; }
        public string ResponseMessage { get; set; }
        public int TotalCount { get; set; }
        public List<String> Errors { get; set; } = new List<string>();

        public BaseResponse() { }

        public BaseResponse(T data, string responseMessage = null)
        {
            this.Data = data;
            this.Status = RequestExecutionEnum.Successful;
            this.ResponseMessage = responseMessage;
        }

        public BaseResponse(T data, int TotalCount, string responseMessage = null)
        {
            this.Data = data;
            this.TotalCount = TotalCount;
            this.Status = RequestExecutionEnum.Successful;
            this.ResponseMessage = responseMessage;
        }

        public BaseResponse(string error, List<string> errors = null)
        {
            this.Status = RequestExecutionEnum.Failed;
            this.ResponseMessage = error;
            this.Errors = errors;
        }

        public BaseResponse(T data, string error, List<string> errors, RequestExecutionEnum status)
        {
            this.Status = status;
            this.ResponseMessage = error;
            this.Errors = errors;
            this.Data = data;
        }
    }
}
