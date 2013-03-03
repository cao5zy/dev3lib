using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Dev3Lib.Web
{
    public static class ContextObjectHelper
    {
        public static T Get<T>() where T : class
        {
            CheckType<T>();

            string contextId = GetContextId<T>();

            return (T)HttpContext.Current.Session[contextId];
        }

        public static T Get<T>(Func<T> createObj) where T : class
        {
            CheckType<T>();

            string contextId = GetContextId<T>();

            var contextObj = HttpContext.Current.Session[contextId];

            if (contextObj == null)
            {
                contextObj = createObj();
                HttpContext.Current.Session[contextId] = contextObj;
            }

            return (T)contextObj;
        }

        public static void Set<T>(T obj) where T : class
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            CheckType<T>();

            string contextId = GetContextId<T>();

            HttpContext.Current.Session[contextId] = obj;
        }

        private static string GetContextId<T>() where T : class
        {
            string contextId = ((ContextObjectAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(ContextObjectAttribute))).ContextId;
            return contextId;
        }

        private static void CheckType<T>() where T : class
        {
            if (!Attribute.IsDefined(typeof(T), typeof(ContextObjectAttribute)))
                throw new ArgumentException("the context type must take ContextObjectAttribute");
        }
    }
}
