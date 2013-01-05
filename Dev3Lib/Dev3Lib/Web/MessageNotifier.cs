using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Dev3Lib.Web
{
    public sealed class MessageNotifier
    {
        private IDictionary _items;
        private static readonly object _lockObj = new object();
        private MessageNotifier()
        {
            _items = HttpContext.Current.Items;
        }
        public sealed class NotifierEventArgs : EventArgs
        {
            public object Data;
        }
        public class Event
        {
            private Delegate _del;

            public event EventHandler<NotifierEventArgs> Notifier
            {
                add { _del = Delegate.Combine(_del, value); }
                remove { Delegate.Remove(_del, value); }
            }

            public void Invoke(object s, NotifierEventArgs e)
            {
                if (_del != null)
                    _del.DynamicInvoke(s, e);
            }
        }

        private static MessageNotifier _notifier = new MessageNotifier();

        public static MessageNotifier Instance
        {
            get
            {
                return _notifier;
            }
        }

        public Event this[string eventName]
        {
            get
            {
                if (!_items.Contains(eventName))
                {
                    lock (_lockObj)
                    {
                        if (!_items.Contains(eventName))
                            _items.Add(eventName, new Event());
                    }
                }

                return (Event)_items[eventName];
            }
        }

    }
}
