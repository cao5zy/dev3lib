using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Compilation;
using System.ComponentModel;
using System.CodeDom;

namespace Dev3Lib.Web
{
    [ExpressionPrefix("dic")]
    public class DicExpressionBuilder : ExpressionBuilder
    {

        public static object GetEvalData(string expression)
        {
            return DicLocation.GetLanguageValue(expression);
        }


        public override System.CodeDom.CodeExpression GetCodeExpression(System.Web.UI.BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            Type type1 = entry.DeclaringType;
            PropertyDescriptor descriptor1 = TypeDescriptor.GetProperties(type1)[entry.PropertyInfo.Name];
            CodeExpression[] expressionArray1 = new CodeExpression[1];
            expressionArray1[0] = new CodePrimitiveExpression(entry.Expression.Trim());
            return new CodeCastExpression(descriptor1.PropertyType, new CodeMethodInvokeExpression(new
           CodeTypeReferenceExpression(base.GetType()), "GetEvalData", expressionArray1));
        }

        public override bool SupportsEvaluate
        {
            get
            {
                return false;
            }
        }
    }
}
