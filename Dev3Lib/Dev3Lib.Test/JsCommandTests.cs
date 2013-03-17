using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Dev3Lib.Web;

namespace Dev3Lib.Test
{
    [TestClass]
    public class JsCommandTests
    {
        [TestMethod]
        public void ToJson_Empty()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            var jsCmd = new JSCommand(dic);

            string expected = "[]";

            Assert.AreEqual(expected, jsCmd.ToJson());
        }

        [TestMethod]
        public void ToJson_OneCommandWithSharp()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            string state = "state1", id = "#1111";
            var jsCmd = new JSCommand(dic);
            jsCmd.AddState(state, id);

            string expected = string.Format("[{{'{0}':'{1}','{2}':'{3}'}}]", JSCommand._stateTag,
                state,
                JSCommand._idTag,
                id
                );

            Assert.AreEqual(expected, jsCmd.ToJson());
        }

        [TestMethod]
        public void ToJson_OneCommandWithOutSharp()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            string state = "state1", id = "1111";
            var jsCmd = new JSCommand(dic);
            jsCmd.AddState(state, id);

            string expected = string.Format("[{{'{0}':'{1}','{2}':'#{3}'}}]", JSCommand._stateTag,
                state,
                JSCommand._idTag,
                id
                );

            Assert.AreEqual(expected, jsCmd.ToJson());
        }

        [TestMethod]
        public void ToJson_TwoCommands()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            string state1 = "state1", id1 = "1111",
                state2 = "state2", id2 = "2222";
            var jsCmd = new JSCommand(dic);
            jsCmd.AddState(state1, id1);
            jsCmd.AddState(state2, id2);

            string expected = string.Format("[{{'{0}':'{1}','{2}':'#{3}'}},{{'{4}':'{5}','{6}':'#{7}'}}]", 
                JSCommand._stateTag,
                state1,
                JSCommand._idTag,
                id1,
                JSCommand._stateTag,
                state2,
                JSCommand._idTag,
                id2
                );

            Assert.AreEqual(expected, jsCmd.ToJson());
        }
    }
}
