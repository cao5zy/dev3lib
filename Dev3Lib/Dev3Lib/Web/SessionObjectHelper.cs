using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web;

namespace Dev3Lib.Web
{
    public static class SessionObjectHelper
    {
        public static T Get<T>() where T : class
        {
            CheckType<T>();

            string sessionId = GetSessionId<T>();

            return (T)HttpContext.Current.Session[sessionId];
        }

        public static T Get<T>(Func<T> createObj) where T : class
        {
            CheckType<T>();

            string sessionId = GetSessionId<T>();

            var sessionObj = HttpContext.Current.Session[sessionId];

            if (sessionObj == null)
            {
                sessionObj = createObj();
                HttpContext.Current.Session[sessionId] = sessionObj;
            }

            return (T)sessionObj;
        }

        public static void Set<T>(T obj) where T : class
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            CheckType<T>();

            string sessionId = GetSessionId<T>();

            HttpContext.Current.Session[sessionId] = obj;
        }

        private static string GetSessionId<T>() where T : class
        {
            string sessionId = ((SessionObjectAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(SessionObjectAttribute))).SessionId;
            return sessionId;
        }

        private static void CheckType<T>() where T : class
        {
            if (!Attribute.IsDefined(typeof(T), typeof(SessionObjectAttribute)))
                throw new ArgumentException("the session type must take SessionObjectAttribute");
        }
    }
}
