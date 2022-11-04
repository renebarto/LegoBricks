﻿using Org.BouncyCastle.Crypto;
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
    public class BrickCategoryIDRule : ValidationRule
    {
        public bool CheckExisting { get; set; }
        public Model.Model? Model { get; set; }
        public CheckExistingBindingWrapper CheckExistingWrapper { get; set; }
        public ModelBindingWrapper ModelWrapper { get; set; }

        public BrickCategoryIDRule()
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
                if (((string)value).Length > 0)
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
            if (CheckExistingWrapper.CheckExisting && ModelWrapper.Model.FindBrickCategory(id) != -1)
            {
                return new ValidationResult(false,
                  $"Please enter a non-existing brick category ID.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
