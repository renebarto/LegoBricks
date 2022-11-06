using LegoBricks.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LegoBricks.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class BrickTypesPage : TabItem
    {
        private ViewModel.BrickTypesViewModel? m_viewModel;

        public BrickTypesPage()
        {
            InitializeComponent();
        }

        private void OnBrickTypesGridDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            m_viewModel = (ViewModel.BrickTypesViewModel)this.DataContext;
        }

        private void AddBrickType_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new BrickTypeEditForm();
            dialog.Title = "Add Brick Type";
            BrickTypeEditViewModel viewModel = new BrickTypeEditViewModel(m_viewModel?.Model, true);
            dialog.DataContext = viewModel;
            if (m_viewModel?.SelectedItem != null)
            {
                BrickTypeData data = m_viewModel.SelectedItem.Value;
                dialog.Data = data;
            }
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                m_viewModel?.AddBrickType(dialog.Data);
            }
        }

        private void EditBrickType_Click(object sender, RoutedEventArgs e)
        {
            var originalData = new BrickTypeData();
            var dialog = new BrickTypeEditForm();
            dialog.Title = "Edit Brick Type";
            BrickTypeEditViewModel viewModel = new BrickTypeEditViewModel(m_viewModel?.Model, false);
            dialog.DataContext = viewModel;
            if (m_viewModel?.SelectedItem != null)
            {
                originalData = m_viewModel.SelectedItem.Value;
            }
            dialog.Data = originalData;
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                m_viewModel?.ChangeBrickType(dialog.Data, originalData);
            }
        }

        private void DeleteBrickType_Click(object sender, RoutedEventArgs e)
        {
            if (m_viewModel?.SelectedItem != null)
            {
                BrickTypeData data = m_viewModel.SelectedItem.Value;
                m_viewModel?.DeleteBrickType(data);
            }
        }

        private void ResetBrickTypes_Click(object sender, RoutedEventArgs e)
        {
            m_viewModel?.ResetBrickTypes();
        }
        private void SaveBrickTypes_Click(object sender, RoutedEventArgs e)
        {
            m_viewModel?.SaveBrickTypes();
        }
    }
}
