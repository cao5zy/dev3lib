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
        private MessageNotifier() {
            _items = HttpContext.Current.Items;
        }

        public class Event
        {
            private Delegate _del;

            public event EventHandler Notifier
            {
                add { _del = Delegate.Combine(_del, value); }
                remove { Delegate.Remove(_del, value); }
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

        public Event GetEvent(string eventName)
        {
            if (!_items.Contains(eventName))
                _items.Add(eventName, new Event());

            return (Event)_items[eventName];

        }

    }
}
