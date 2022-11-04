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
    public partial class BrickCategoryEditForm : Window
    {
        private BrickCategoryData m_data;
        public BrickCategoryData Data
        {
            get { return m_data; } 
            set 
            { 
                m_data = value;
                var viewModel = (ViewModel.BrickCategoryEditViewModel)this.DataContext;
                viewModel.BrickCategoryID = m_data.id.ToString();
                viewModel.BrickCategoryName = m_data.name;
            }
        }

        public BrickCategoryEditForm()
        {
            InitializeComponent();
            BrickCategoryID.Focus();
            BrickCategoryID.SelectAll();
        }

        private void OnOK_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ViewModel.BrickCategoryEditViewModel)this.DataContext;
            try
            {
                Data = new BrickCategoryData(Int32.Parse(viewModel.BrickCategoryID), viewModel.BrickCategoryName);
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
    }
}
