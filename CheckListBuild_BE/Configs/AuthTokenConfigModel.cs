namespace CheckListBuild_BE.Configs
{
    public class AuthTokenConfigModel
    {
        public string SecretKey { get; set; }

        public string ExpiredTime { get; set; }

        public AuthTokenConfigModel(string secretKey, string expiredTime)
        {
            SecretKey = secretKey;
            ExpiredTime = expiredTime;
        }
    }
}
