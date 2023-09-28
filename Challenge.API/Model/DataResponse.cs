namespace Challenge.API.Model
{
    public class DataResponse<T>
    {
        public string message { get; set; }
        public int status { get; set; }
        public T data { get; set; }
    }
}
