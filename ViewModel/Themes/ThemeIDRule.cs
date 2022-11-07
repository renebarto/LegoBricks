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
    public class ThemeIDRule : ValidationRule
    {
        public bool CheckExisting { get; set; }
        public Model.Model? Model { get; set; }
        public CheckExistingBindingWrapper CheckExistingWrapper { get; set; }
        public ModelBindingWrapper ModelWrapper { get; set; }

        public ThemeIDRule()
        {
            CheckExistingWrapper = new CheckExistingBindingWrapper();
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
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Please enter a valid number: {e.Message}");
            }

            if (ModelWrapper.Model == null)
            {
                return new ValidationResult(false, $"Panic! No model.");
            }
            if (CheckExistingWrapper.CheckExisting && ModelWrapper.Model.FindTheme(id) != -1)
            {
                return new ValidationResult(false, $"Please enter a non-existing theme ID.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
