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
    public class BrickCategoryNameRule : ValidationRule
    {
        public bool CheckExisting { get; set; }
        public Model.Model? Model { get; set; }
        public ModelBindingWrapper Wrapper { get; set; }

        public BrickCategoryNameRule()
        {
            Wrapper = new ModelBindingWrapper();
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (String.IsNullOrEmpty((string?)value))
            {
                return new ValidationResult(false, $"Please enter a valid name: empty field");
            }
            return ValidationResult.ValidResult;
        }
    }
}
