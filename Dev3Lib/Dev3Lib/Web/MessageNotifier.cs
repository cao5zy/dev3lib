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
        private IDictionary<string, Event> _items = new Dictionary<string, Event>();
        private static readonly object _lockObj = new object();

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

            public void Notify(object s, NotifierEventArgs e)
            {
                if (_del != null)
                    _del.DynamicInvoke(s, e);
            }
        }

        const string _itemKey = "{A02E750B-F64C-46C0-AC8A-0793E691C5C1}";
        public static MessageNotifier Instance
        {
            get
            {
                if (!HttpContext.Current.Items.Contains(_itemKey))
                    HttpContext.Current.Items.Add(_itemKey, new MessageNotifier());

                return (MessageNotifier)HttpContext.Current.Items[_itemKey];
            }
        }

        public Event this[string eventName]
        {
            get
            {
                if (!_items.ContainsKey(eventName))
                    _items.Add(eventName, new Event());

                return _items[eventName];
            }
        }

    }
}
