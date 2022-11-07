using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace LegoBricks.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ColorEditForm : Window
    {
        private ColorData m_data;
        public ColorData Data
        {
            get { return m_data; } 
            set 
            { 
                m_data = value;
                var viewModel = (ViewModel.ColorEditViewModel)this.DataContext;
                viewModel.ColorID = m_data.id.ToString();
                viewModel.ColorName = m_data.name;
                viewModel.ColorRGB = m_data.rgb;
                viewModel.ColorTransparent = m_data.transparent;
            }
        }

        public ColorEditForm()
        {
            InitializeComponent();
            ColorID.Focus();
            ColorID.SelectAll();
        }

        private void OnClickOK(object sender, RoutedEventArgs e)
        {
            var viewModel = (ViewModel.ColorEditViewModel)this.DataContext;
            try
            {
                Data = new ColorData(Int32.Parse(viewModel.ColorID), viewModel.ColorName, viewModel.ColorRGB, viewModel.ColorTransparent);
                this.DialogResult = true;
            }
            catch (Exception /*e*/)
            {
                // This should never happen, as we use validators
                this.DialogResult = false;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? tb = sender as TextBox;
            Dispatcher.BeginInvoke(new SelectAllDelegate(SelectAll), tb);
        }

        private void RGB_LostFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = (ViewModel.ColorEditViewModel)this.DataContext;
            viewModel.ColorImageBackground = viewModel.ColorImageBackground;
        }

        private delegate void SelectAllDelegate(TextBox tb);

        private void SelectAll(TextBox tb)
        {
            tb.SelectAll();
        }
    }
}
