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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel.MainViewModel? m_viewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnMainGridDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            m_viewModel = (ViewModel.MainViewModel)this.DataContext;
        }

        private void AddBrickCategory_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new BrickCategoryEditForm();
            dialog.Title = "Add Brick Category";
            BrickCategoryEditViewModel viewModel = new BrickCategoryEditViewModel(m_viewModel?.Model, true);
            dialog.DataContext = viewModel;
            if (m_viewModel?.SelectedItem != null)
            {
                BrickCategoryData data = m_viewModel.SelectedItem.Value;
                dialog.Data = data;
            }
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                m_viewModel?.AddBrickCategory(dialog.Data);
            }
        }

        private void EditBrickCategory_Click(object sender, RoutedEventArgs e)
        {
            var originalData = new BrickCategoryData();
            var dialog = new BrickCategoryEditForm();
            dialog.Title = "Edit Brick Category";
            BrickCategoryEditViewModel viewModel = new BrickCategoryEditViewModel(m_viewModel?.Model, false);
            dialog.DataContext = viewModel;
            if (m_viewModel?.SelectedItem != null)
            {
                originalData = m_viewModel.SelectedItem.Value;
            }
            dialog.Data = originalData;
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                m_viewModel?.ChangeBrickCategory(dialog.Data, originalData);
            }
        }

        private void DeleteBrickCategory_Click(object sender, RoutedEventArgs e)
        {
            if (m_viewModel?.SelectedItem != null)
            {
                BrickCategoryData data = m_viewModel.SelectedItem.Value;
                m_viewModel?.DeleteBrickCategory(data);
            }
        }

        private void ResetBrickCategories_Click(object sender, RoutedEventArgs e)
        {
            m_viewModel?.ResetBrickCategories();
        }
        private void SaveBrickCategories_Click(object sender, RoutedEventArgs e)
        {
            m_viewModel?.SaveBrickCategories();
        }
    }
}
