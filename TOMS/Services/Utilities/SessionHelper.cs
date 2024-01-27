using Newtonsoft.Json;

namespace TOMS.Services.Utilities
{
    public static class SessionHelper
    {
        public static void SetDataToSession(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetDataFromSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void ClearSession(this ISession session)
        {
            session.Clear();
        }
    }
}
