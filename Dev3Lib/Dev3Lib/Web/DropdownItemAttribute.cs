using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Web
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DropdownItemAttribute : Attribute
    {
        public readonly string TextFieldName;
        public readonly string DataFieldName;
        public readonly bool HasDefault;
        public readonly string DefaultText;
        public readonly string DefaultData;
        public DropdownItemAttribute(string textFieldName, string dataFieldName)
            : base()
        {
            TextFieldName = textFieldName;
            DataFieldName = dataFieldName;
        }

        public DropdownItemAttribute(string textFieldName, string dataFieldName, string defaultText, string defaultData)
            : base()
        {


            DefaultData = defaultData;
            DefaultText = defaultText;

            TextFieldName = textFieldName;
            DataFieldName = dataFieldName;

            HasDefault = true;
        }
    }
}
