using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
    public partial class SetEditForm : Window
    {
        private SetData m_data;
        public SetData Data
        {
            get { return m_data; } 
            set 
            { 
                m_data = value;
                var viewModel = (ViewModel.SetEditViewModel)this.DataContext;
                viewModel.SetID = m_data.id.ToString();
                viewModel.SetName = m_data.name;
                viewModel.SetPartCount = m_data.partCount.ToString();
                int index = viewModel.Model?.FindTheme(m_data.themeID) ?? -1;
                index = (index == -1) ? 0 : index;
                viewModel.SetThemeID = viewModel.ThemesSource[index];
                viewModel.SetYear = m_data.year.ToString();
            }
        }

        public SetEditForm()
        {
            InitializeComponent();
            SetID.Focus();
            SetID.SelectAll();
            SetThemeID.SelectedIndex = 0;
        }

        private void OnClickOK(object sender, RoutedEventArgs e)
        {
            var viewModel = (ViewModel.SetEditViewModel)this.DataContext;
            try
            {
                int themeID = -1;
                if (viewModel.Model != null)
                {
                    themeID = viewModel.Model.ExtractThemeID(viewModel.SetThemeID);
                }
                Data = new SetData(viewModel.SetID, viewModel.SetName, Int32.Parse(viewModel.SetPartCount), themeID, Int32.Parse(viewModel.SetYear));
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

        private delegate void SelectAllDelegate(TextBox tb);

        private void SelectAll(TextBox tb)
        {
            tb.SelectAll();
        }
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (ViewModel.SetEditViewModel)this.DataContext;
        }

    }
}
