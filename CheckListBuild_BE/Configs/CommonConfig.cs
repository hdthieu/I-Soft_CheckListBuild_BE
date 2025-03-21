using CheckListBuild_BE.Entities;
using DotNetEnv;
using Microsoft.AspNetCore.DataProtection;
namespace CheckListBuild_BE.Configs
{
    public class CommonConfig
    {
        public static string EncryptHandshakeSecretKey => GetEnvData("ENCRYPT_HANDSHAKE_SECRET_KEY");
        public static string GetEnvData(string configKey)
        {
            string environmentVariable = Environment.GetEnvironmentVariable(configKey);
            if (environmentVariable == null)
            {
                Env.Load();
                environmentVariable = Environment.GetEnvironmentVariable(configKey);
                Console.WriteLine("environmentVariable  " + environmentVariable);
            }

            if (environmentVariable == null)
            {
                throw new BaseException("Get config from ENV error, ConfigKey: " + configKey);
            }

            return environmentVariable;
        }
        public static AuthTokenConfigModel AccessTokenConfig
        {
            get
            {
                string envData = GetEnvData("AUTH_TOKEN_CONFIG__ACCESS_TOKEN_SECRECT");
                string envData2 = GetEnvData("AUTH_TOKEN_CONFIG__ACCESS_TOKEN_EXPIRED");
                return new AuthTokenConfigModel(envData, envData2);
            }
        }
    }
}
