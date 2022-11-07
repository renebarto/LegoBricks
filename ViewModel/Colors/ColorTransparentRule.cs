using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace LegoBricks.ViewModel
{
    public class ColorTransparentRule : ValidationRule
    {
        public bool CheckExisting { get; set; }
        public Model.Model? Model { get; set; }
        public ModelBindingWrapper Wrapper { get; set; }

        public ColorTransparentRule()
        {
            Wrapper = new ModelBindingWrapper();
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!(value is bool))
            {
                return new ValidationResult(false, $"Incorrect type: not boolean");
            }
            return ValidationResult.ValidResult;
        }
    }
}
