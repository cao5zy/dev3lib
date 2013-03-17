using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Dev3Lib.Web
{
    public sealed class JSCommand
    {
        const string _stateBagId = "{63D9B516-1EE3-42EE-AEE3-E83EBAB1AC11}";
        public const string _stateTag = "state", _idTag = "id";
        private static Dictionary<string, string> Bag
        {
            get
            {
                if (HttpContext.Current.Items[_stateBagId] == null)
                    HttpContext.Current.Items[_stateBagId] = new Dictionary<string, string>();

                return (Dictionary<string, string>)HttpContext.Current.Items[_stateBagId];
            }
        }

        private IDictionary<string, string> _jsCmdDic = null;
        public JSCommand()
        {
            _jsCmdDic = Bag;
        }

        public JSCommand(IDictionary<string, string> cmdDic)
        {
            _jsCmdDic = cmdDic;
        }

        public void AddState(string stateKey, string id)
        {
            if (!id.StartsWith("#"))
                id = "#" + id;
            _jsCmdDic.Add(stateKey, id);
        }

        public bool ContainsKey(string stateKey)
        {
            return _jsCmdDic.ContainsKey(stateKey);
        }

        public string ToJson()
        {
            if (_jsCmdDic.Count == 0)
                return "[]";
            else
            {
                return string.Format("[{0}]",
                    string.Join(",",
                        _jsCmdDic.Select(n => string.Format("{{'{0}':'{1}','{2}':'{3}'}}", _stateTag, n.Key, _idTag, n.Value)).ToArray()));
            }
        }
    }
}
