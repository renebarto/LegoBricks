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
    public class ModelBindingProxy : System.Windows.Freezable
    {        
        protected override Freezable CreateInstanceCore()
        {
            return new ModelBindingProxy();
        }

        public object Model
        {
            get { return (object)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(object), typeof(ModelBindingProxy), new PropertyMetadata(null));
    }
}
