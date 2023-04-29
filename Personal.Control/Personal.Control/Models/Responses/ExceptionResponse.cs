using Personal.Control.Models.Enums;

namespace Personal.Control.Models.Responses
{
    public class ExceptionResponse
    {
        public string Code { get; }
        public string Message { get; }
        
        public ExceptionResponse(ExceptionCodesEnum code, string message) 
        { 
            Code = code.ToString();
            Message = message;
        }
    }
}
