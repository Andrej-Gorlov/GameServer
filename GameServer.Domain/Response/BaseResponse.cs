namespace GameServer.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T? Result { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
    public interface IBaseResponse<T>
    {
        public T? Result { get; set; }
    }
}
