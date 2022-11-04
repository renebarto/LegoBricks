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
    public class ModelBindingWrapper : DependencyObject
    {
        public static readonly DependencyProperty ModelProperty =
             DependencyProperty.Register("Model", typeof(Model.Model), typeof(ModelBindingWrapper), new FrameworkPropertyMetadata(null));

        public Model.Model Model
        {
            get { return (Model.Model)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }
    }
}
