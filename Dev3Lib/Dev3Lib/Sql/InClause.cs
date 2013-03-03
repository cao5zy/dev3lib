using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev3Lib.Algorithms;

namespace Dev3Lib.Sql
{
    public class InClause : WhereClause
    {
        public InClause(IEnumerable<string> values,
            string columnName)
            : base(values, columnName) {

        }

        public InClause(IEnumerable<object> values,
            string columnName)
            : base(values, columnName) {

        }

        protected override string ToCurrentWhereClause()
        {
            IEnumerable<object> values = (IEnumerable<object>)Value;
            List<string> paramList = new List<string>();
            int count = values.Count();

            if (values is IEnumerable<string>)
            {
                for (int i = 0; i < count; i++)
                { 
                    if(i == 0)
                        paramList.Add(string.Format("'{0}'", ParamName));
                    else
                        paramList.Add(string.Format("'{0}{1}'", ParamName, i));
                }
            }
            else
            { 
                 for (int i = 0; i < count; i++)
                { 
                    if(i == 0)
                        paramList.Add(string.Format("{0}", ParamName));
                    else
                        paramList.Add(string.Format("{0}{1}", ParamName, i));
                }
            }

            return string.Format("{0} in ({1})", ColumnName, paramList.SafeJoinWith(","));
        }

        protected override IEnumerable<object> ToValues()
        {
            return (IEnumerable<object>)Value;
        }
    }
}
