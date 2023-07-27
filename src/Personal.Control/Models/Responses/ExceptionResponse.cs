using Personal.Control.Models.Enums;

namespace Personal.Control.Models.Responses
{
    public class ExceptionResponse
    {
        /// <summary>
        /// Exception code to help clients understand the error
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Exception message descriptor
        /// </summary>
        public string Message { get; }

        public ExceptionResponse(ExceptionCodesEnum code, string message)
        {
            Code = code.ToString();
            Message = message;
        }
    }
}
