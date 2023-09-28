namespace ExceptionCategories
{
    public class ExceptionCreateCategories : Exception
    {
        private const string _message = "Error save categories try again";
        public ExceptionCreateCategories() : base($"{_message}") { }
    }
}