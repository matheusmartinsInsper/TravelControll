namespace TravelControll.Models
{
    public class Response<T>
    {
        private string _status;
        private string _message;

        public string status { get { return _status; } set { _status = value; } }
        public string? message { get { return _message; } set { _message = value; } }
        public T? data { get; set; }
    }
}
