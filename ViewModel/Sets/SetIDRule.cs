using MySqlX.XDevAPI.Common;
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
    public class SetIDRule : ValidationRule
    {
        public bool CheckExisting { get; set; }
        public Model.Model? Model { get; set; }
        public CheckExistingBindingWrapper CheckExistingWrapper { get; set; }
        public ModelBindingWrapper ModelWrapper { get; set; }

        public SetIDRule()
        {
            CheckExistingWrapper = new CheckExistingBindingWrapper();
            ModelWrapper = new ModelBindingWrapper();
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string id;

            try
            {
                if (String.IsNullOrEmpty((string?)value))
                {
                    return new ValidationResult(false, $"Please enter a valid set id: empty field");
                }
                var text = (string)value;
                var parts = text.Split('-');
                if ((parts.Length == 1) || (parts.Length == 2))
                {
                    Int32.Parse(parts[0]);
                    if (parts.Length > 1)
                        Int32.Parse(parts[1]);
                }
                else 
                {
                    return new ValidationResult(false, $"Please enter a valid set id in format <ddddd>[-<d>]");
                }
                id = text;
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Please enter a valid number: {e.Message}");
            }

            if (ModelWrapper.Model == null)
            {
                return new ValidationResult(false, $"Panic! No model.");
            }
            if (CheckExistingWrapper.CheckExisting && ModelWrapper.Model.FindSet(id) != -1)
            {
                return new ValidationResult(false, $"Please enter a non-existing set ID.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
