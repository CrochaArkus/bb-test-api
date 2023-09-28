namespace ExceptionCategories
{
    public class ExceptionCategoryNoExist : Exception
    {
        private const string _message = "Error category no exist";
        public ExceptionCategoryNoExist() : base($"{_message}") { }
    }
}
