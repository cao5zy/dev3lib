using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dev3Lib.DataValidations
{
    public class IdentityCardValidationAttribute : RegularExpressionAttribute
    {
        public IdentityCardValidationAttribute(string errorMessage = "身份证号码格式不正确")
            : base(@"^\d{14}\d{3}?\w$")
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
