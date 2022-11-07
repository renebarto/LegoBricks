using LegoBricks.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LegoBricks.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ColorsPage : TabItem
    {
        private ViewModel.ColorsViewModel? m_viewModel;

        public ColorsPage()
        {
            InitializeComponent();
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            m_viewModel = (ViewModel.ColorsViewModel)this.DataContext;
        }

        private void OnClickAdd(object sender, RoutedEventArgs e)
        {
            var dialog = new ColorEditForm();
            dialog.Title = "Add Color";
            ColorEditViewModel viewModel = new ColorEditViewModel(m_viewModel?.Model, true);
            dialog.DataContext = viewModel;
            if (m_viewModel?.SelectedItem != null)
            {
                ColorData data = m_viewModel.SelectedItem.Value;
                dialog.Data = data;
            }
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                m_viewModel?.AddColor(dialog.Data);
            }
        }

        private void OnClickEdit(object sender, RoutedEventArgs e)
        {
            var originalData = new ColorData();
            var dialog = new ColorEditForm();
            dialog.Title = "Edit Color";
            ColorEditViewModel viewModel = new ColorEditViewModel(m_viewModel?.Model, false);
            dialog.DataContext = viewModel;
            if (m_viewModel?.SelectedItem != null)
            {
                originalData = m_viewModel.SelectedItem.Value;
            }
            dialog.Data = originalData;
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                m_viewModel?.ChangeColor(dialog.Data, originalData);
            }
        }

        private void OnClickDelete(object sender, RoutedEventArgs e)
        {
            if (m_viewModel?.SelectedItem != null)
            {
                ColorData data = m_viewModel.SelectedItem.Value;
                m_viewModel?.DeleteColor(data);
            }
        }

        private void OnClickReset(object sender, RoutedEventArgs e)
        {
            m_viewModel?.ResetColors();
        }

        private void OnClickSave(object sender, RoutedEventArgs e)
        {
            m_viewModel?.SaveColors();
        }
    }
}
