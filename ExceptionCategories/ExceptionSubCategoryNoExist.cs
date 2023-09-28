namespace ExceptionCategories
{
    public class ExceptionSubCategoryNoExist : Exception
    {
        private const string _message = "Error subcategory no exist";
        public ExceptionSubCategoryNoExist() : base($"{_message}") { }
    }
    
}
