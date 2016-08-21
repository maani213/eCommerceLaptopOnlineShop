using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Custom_Validation
{
    public class SelectionListRequiredAttribute : ValidationAttribute
    {
        #region Overrides
        //public override bool IsValid(object value)
        //{
        //    // no validation for non integer values
        //    if (!(value is int))
        //        return true;

        //    // all my selection lists have a certain ID that means <no selection>
        //    // if this option is not available, value must be checked for null
        //    return (int)value != null;
        //}

        // you may customize your error message here
        public override string FormatErrorMessage(string name)
        {
            return String.Format("{0} must be specified", name);
        }
        #endregion
    }
}