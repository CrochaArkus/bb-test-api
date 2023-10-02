namespace ExceptionContents
{
    public class ExecptionCreateContent : Exception
    {
        private const string _message = "Error create content try again";
        public ExecptionCreateContent() : base($"{_message}") { }
    }    
}