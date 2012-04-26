using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dev3Lib
{
    public static class Notification<T>
    {
        public interface IReceiver
        {
            void Receive(object sender, T notifiedObj);
        }

        static List<WeakReference> receiverList = new List<WeakReference>();
        static readonly object lockObj = new object();
        public static void Register(IReceiver receiver)
        {
            lock (lockObj)
            {
                var item = receiverList.Find(n => n.Target == receiver);
                if (item == null)
                    receiverList.Add(new WeakReference(receiver));
            }
        }

        public static void Send(object sender, T notifiedObj)
        {
            lock (lockObj)
            {
                List<WeakReference> canBeRemoved = new List<WeakReference>();
                foreach (var receiver in receiverList)
                {
                    var concretReceiver = receiver.Target as IReceiver;
                    if (concretReceiver != null)
                    {
                        var form = concretReceiver as Control;
                        if (form != null)
                        {
                            if (!form.IsDisposed)
                                concretReceiver.Receive(sender, notifiedObj);
                            else
                                canBeRemoved.Add(receiver);
                        }
                        else
                            concretReceiver.Receive(sender, notifiedObj);
                    }
                    else
                        canBeRemoved.Add(receiver);
                }

                canBeRemoved.ForEach(n => receiverList.Remove(n));
            }
        }

        public static int GetReceiverCount()
        {
            return receiverList.Count;
        }
    }
}
