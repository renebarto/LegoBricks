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
    public class SetThemeIDRule : ValidationRule
    {
        public bool CheckExisting { get; set; }
        public Model.Model? Model { get; set; }
        public ModelBindingWrapper ModelWrapper { get; set; }

        public SetThemeIDRule()
        {
            ModelWrapper = new ModelBindingWrapper();
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int themeID = 0;

            if (String.IsNullOrEmpty((string?)value))
            {
                return new ValidationResult(false, $"Please enter a valid number: empty field");
            }
            if (ModelWrapper.Model != null)
            {
                themeID = ModelWrapper.Model.ExtractThemeID((string)value);
                if (themeID == -1)
                {
                    return new ValidationResult(false, $"Please enter a valid theme ID");
                }
            }

            if (ModelWrapper.Model == null)
            {
                return new ValidationResult(false, $"Panic! No model.");
            }
            if (ModelWrapper.Model.FindTheme(themeID) == -1)
            {
                return new ValidationResult(false, $"Please enter an existing theme ID.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
