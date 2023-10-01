namespace ExceptionCategories
{
    public class ExceptionCretaetInteriorSubcategories : Exception
    {
        private const string _message = "Error save interiorsubcategories try again";
        public ExceptionCretaetInteriorSubcategories() : base($"{_message}") { }
    }
    
}
