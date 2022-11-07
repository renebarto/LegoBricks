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
    public partial class ThemeEditForm : Window
    {
        private ThemeData m_data;
        public ThemeData Data
        {
            get { return m_data; } 
            set 
            { 
                m_data = value;
                var viewModel = (ViewModel.ThemeEditViewModel)this.DataContext;
                viewModel.ThemeID = m_data.id.ToString();
                viewModel.ThemeName = m_data.name;
                int index = -1;
                if (m_data.parentID != null)
                {
                    index = viewModel.Model?.FindTheme(m_data.parentID.Value) ?? -1;
                }
                viewModel.ThemeParentID = (index != -1) ? viewModel.ThemesSource[index].ThemeDescription : "-";
            }
        }

        public ThemeEditForm()
        {
            InitializeComponent();
            ThemeID.Focus();
            ThemeID.SelectAll();
            ThemeParentID.SelectedIndex = 0;
        }

        private void OnClickOK(object sender, RoutedEventArgs e)
        {
            var viewModel = (ViewModel.ThemeEditViewModel)this.DataContext;
            try
            {
                int parentID = -1;
                if (viewModel.Model != null)
                {
                    parentID = viewModel.Model.ExtractThemeID(viewModel.ThemeParentID);
                }
                Data = new ThemeData(Int32.Parse(viewModel.ThemeID), viewModel.ThemeName, parentID);
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
            var viewModel = (ViewModel.ThemeEditViewModel)this.DataContext;
        }
    }
}
