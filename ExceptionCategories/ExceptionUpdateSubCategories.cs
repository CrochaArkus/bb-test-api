namespace ExceptionCategories
{
    public class ExceptionUpdateSubCategories : Exception
    {
        private const string _message = "Error modifying subcategory try again";
        public ExceptionUpdateSubCategories() : base($"{_message}") { }
    }
    
}
