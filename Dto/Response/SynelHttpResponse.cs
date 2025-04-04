namespace SynelTestTask.Dto.Response
{
    public class SynelHttpResponse<T>
    {
        public enum HttpStatus
        {
            OK,
            BAD_REQUEST,
            NOT_FOUND,
            FAILED,
            INTERNAL_SERVER_ERROR
        }

        public string? Message { get; set; }

        public HttpStatus? Status { get; set; } = HttpStatus.OK;

        public T? Object { get; set; }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public class Builder
        {
            private readonly SynelHttpResponse<T> _response;

            public Builder()
            {
                _response = new SynelHttpResponse<T>();
            }

            public Builder WithMessage(string message)
            {
                _response.Message = message;
                return this;
            }

            public Builder WithStatus(HttpStatus status)
            {
                _response.Status = status;
                return this;
            }

            public Builder WithObject(T obj)
            {
                _response.Object = obj;
                return this;
            }

            public SynelHttpResponse<T> Build()
            {
                return _response;
            }
        }
    }
}
