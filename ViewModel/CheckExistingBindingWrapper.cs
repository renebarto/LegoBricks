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
    public class CheckExistingBindingWrapper : DependencyObject
    {
        public static readonly DependencyProperty CheckExistingProperty =
             DependencyProperty.Register("CheckExisting", typeof(bool), typeof(CheckExistingBindingWrapper), new FrameworkPropertyMetadata(null));

        public bool CheckExisting
        {
            get { return (bool)GetValue(CheckExistingProperty); }
            set { SetValue(CheckExistingProperty, value); }
        }
    }
}
