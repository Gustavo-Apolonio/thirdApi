namespace thirdApi.Models.Response
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Error { get; set; }

        public ErrorResponse(int code, string error)
        {
            this.Code = code;
            this.Error = error;
        }
    }
}