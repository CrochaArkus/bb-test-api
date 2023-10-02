namespace ExceptionContents
{
    public class ExceptionCreateManageContent : Exception
    {
        private const string _message = "Error create manage content try again";
        public ExceptionCreateManageContent() : base($"{_message}") { }
    
    }
}
