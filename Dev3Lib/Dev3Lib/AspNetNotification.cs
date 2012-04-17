using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Dev3Lib
{
    public static class AspNetNotification<T>
    {
        private static List<Action<object, T>> mNotifyList = new List<Action<object, T>>();
        private static List<string> mErrorList = new List<string>();
        public static void RegisterNotification(Action<object, T> action)
        {
            mNotifyList.Add(action);
        }

        public static void Send(object sender, T e)
        {
            foreach (var notification in mNotifyList)
            {
                try
                {
                    notification(sender, e);
                }
                catch (Exception ex)
                {
                    mErrorList.Add(string.Format("message:{0}\r\nstackTrace:{1}", ex.Message, ex.StackTrace));
                }
            }
        }

        public static string[] Errors
        {
            get
            {
                return mErrorList.ToArray();
            }
        }
    }
}
