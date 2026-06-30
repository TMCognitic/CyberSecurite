namespace Patterns.Results
{
    public class Result
    {
        public static implicit operator Result(Error error)
        {
            return Failure(error.Message);
        }

        public static implicit operator Result(Exception exception)
        {
            return Failure(exception.Message);
        }

        public static Result Success()
        {
            return new Result(true);
        }

        public static Result Failure(string message)
        {
            ArgumentException.ThrowIfNullOrEmpty(message, nameof(message));
            return new Result(false, message);
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? ErrorMessage { get; }

        private Result(bool isSuccess, string? message = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = message;
        }
    }

    public class Result<TData>
    {
        public static explicit operator Result<TData>(TData data)
        {
            return Success(data);
        }

        public static implicit operator Result<TData>(Error error)
        {
            return Failure(error.Message);
        }

        public static implicit operator Result<TData>(Exception exception)
        {
            return Failure(exception.Message);
        }

        public static Result<TData> Success(TData data)
        {
            return new Result<TData>(true, data: data);
        }

        public static Result<TData> Failure(string message)
        {
            ArgumentException.ThrowIfNullOrEmpty(message, nameof(message));
            return new Result<TData>(false, message);
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? ErrorMessage { get; }
        public TData Data { get; }

        private Result(bool isSuccess, string? message = null, TData data = default!)
        {
            IsSuccess = isSuccess;
            ErrorMessage = message;
            Data = data;
        }
    }
}
