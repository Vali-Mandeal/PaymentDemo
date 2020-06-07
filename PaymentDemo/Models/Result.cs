namespace PaymentDemo.Models
{
    public class Result
    {
        public bool IsSuccessful { get; private set; }
        public bool IsFailed => !IsSuccessful;
        public string Error { get; private set; }

        public static Result Ok() =>    
            new Result
            {
                IsSuccessful = true,
            };

        public static Result Fail(string errorMessage) =>
            new Result
            {
                IsSuccessful = false,
                Error = errorMessage
            };
    }
        
    public class Result<T>
    {
        public bool IsSuccessful { get; private set; }
        public bool IsFailed => !IsSuccessful;
        public string Error { get; private set; }
        public T Value { get; set; }

        public static Result<T> Ok(T value) =>
            new Result<T>
            {
                IsSuccessful = true,
                Value = value
            };

        public static Result<T> Fail(string errorMessage, T value) =>
            new Result<T>
            {
                IsSuccessful = false,
                Error = errorMessage,
                Value = value
            };
    }
}
