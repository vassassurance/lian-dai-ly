using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace LianAgentPortal.Commons.Constants
{
    public static class GeneralConstants
    {
        public static string APP_NAME_AUTHENTICATOR { get { return "AppNameAuthenticator"; } }

        public static string DIGITAL_SIGN_SUBJECT_NAME { get { return "CN=*.lian.vn"; } }

        public static JsonSerializerOptions CamelCaseJsonSerializerOptions
        {
            get
            {
                return new JsonSerializerOptions() { 
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                };
            }
        }
    }
}
