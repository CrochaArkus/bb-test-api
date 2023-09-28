namespace ExceptionCategories
{
    public class ExceptionCreateSubCategories : Exception
    {
        private const string _message = "Error save subcategories try again";
        public ExceptionCreateSubCategories() : base($"{_message}") { }
    }
}
