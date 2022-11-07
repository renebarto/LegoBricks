using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace LegoBricks.ViewModel
{
    public class SetYearRule : ValidationRule
    {
        public bool CheckExisting { get; set; }
        public Model.Model? Model { get; set; }
        public ModelBindingWrapper ModelWrapper { get; set; }

        public SetYearRule()
        {
            ModelWrapper = new ModelBindingWrapper();
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int id = 0;

            try
            {
                if (String.IsNullOrEmpty((string?)value))
                {
                    return new ValidationResult(false, $"Please enter a valid number: empty field");
                }
                id = Int32.Parse((String)value);
                if ((id < 1950) | (id > DateTime.Today.Year))
                {
                    return new ValidationResult(false, $"Please enter a valid year number");
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Please enter a valid number: {e.Message}");
            }

            if (ModelWrapper.Model == null)
            {
                return new ValidationResult(false, $"Panic! No model.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
