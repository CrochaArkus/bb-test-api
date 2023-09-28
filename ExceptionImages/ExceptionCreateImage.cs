namespace ExceptionImages
{
    public class ExceptionCreateImage : Exception
    {
        private const string _message = "Error save image try again";
        public ExceptionCreateImage() : base($"{_message}") { }
    }    
}