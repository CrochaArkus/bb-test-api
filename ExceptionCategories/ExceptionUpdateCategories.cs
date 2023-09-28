namespace ExceptionCategories
{
    public class ExceptionUpdateCategories : Exception
    {
        private const string _message = "Error modifying category try again";
        public ExceptionUpdateCategories() : base($"{_message}") { }
    }
}
