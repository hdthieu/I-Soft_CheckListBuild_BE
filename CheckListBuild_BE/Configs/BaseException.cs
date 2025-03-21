namespace CheckListBuild_BE.Configs
{

    public class BaseException : Exception
    {
        public BaseException(string? message)
            : base(message)
        {
        }

        public BaseException(Exception ex)
            : base(ex.ToString())
        {
        }

        public BaseException(string message, Exception ex)
            : base(message + ex.ToString())
        {
        }
    }
}
