using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dev3Lib.DataValidations
{
    public class CellPhoneValidationAttribute : RegularExpressionAttribute
    {
        public CellPhoneValidationAttribute(string errorMessage = "手机号码格式不正确")
            : base("^1[0-9]{10}$")
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
