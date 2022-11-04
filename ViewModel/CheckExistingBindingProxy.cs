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
    public class CheckExistingBindingProxy : System.Windows.Freezable
    {        
        protected override Freezable CreateInstanceCore()
        {
            return new CheckExistingBindingProxy();
        }

        public object CheckExisting
        {
            get { return (object)GetValue(CheckExistingProperty); }
            set { SetValue(CheckExistingProperty, value); }
        }

        public static readonly DependencyProperty CheckExistingProperty =
            DependencyProperty.Register("CheckExisting", typeof(object), typeof(CheckExistingBindingProxy), new PropertyMetadata(null));
    }
}
