using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace LegoBricks.ViewModel
{
    public class ColorRGBRule : ValidationRule
    {
        public bool CheckExisting { get; set; }
        public Model.Model? Model { get; set; }
        public ModelBindingWrapper ModelWrapper { get; set; }

        public ColorRGBRule()
        {
            ModelWrapper = new ModelBindingWrapper();
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var text = (string?)value;
            if (String.IsNullOrEmpty(text))
            {
                return new ValidationResult(false, $"Please enter a valid RGB value: empty field");
            }
            if ((text.Length != 6) || !Regex.IsMatch(text, "^[a-fA-F0-9]*$"))
            {
                return new ValidationResult(false, $"Please enter a valid RGB value: exactly 6 hex digits");
            }
            return ValidationResult.ValidResult;
        }
    }
}
