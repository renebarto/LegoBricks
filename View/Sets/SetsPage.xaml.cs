using LegoBricks.Model;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LegoBricks.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SetsPage : TabItem
    {
        private ViewModel.SetsViewModel? m_viewModel;

        public SetsPage()
        {
            InitializeComponent();
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            m_viewModel = (ViewModel.SetsViewModel)this.DataContext;
        }

        private void OnClickAdd(object sender, RoutedEventArgs e)
        {
            var dialog = new SetEditForm();
            dialog.Title = "Add Set";
            SetEditViewModel viewModel = new SetEditViewModel(m_viewModel?.Model, true);
            dialog.DataContext = viewModel;
            if (m_viewModel?.SelectedItem != null)
            {
                SetDataPresentation data = m_viewModel.SelectedItem.Value;
                dialog.Data = data.data;
            }
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var model = m_viewModel?.Model;
                if (model != null)
                    m_viewModel?.AddSet(new SetDataPresentation(dialog.Data, model.GetThemeDescription(dialog.Data.ThemeID)));
            }
        }

        private void OnClickEdit(object sender, RoutedEventArgs e)
        {
            var originalData = new SetDataPresentation();
            var dialog = new SetEditForm();
            dialog.Title = "Edit Set";
            SetEditViewModel viewModel = new SetEditViewModel(m_viewModel?.Model, false);
            dialog.DataContext = viewModel;
            if (m_viewModel?.SelectedItem != null)
            {
                originalData = m_viewModel.SelectedItem.Value;
            }
            dialog.Data = originalData.data;
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var model = m_viewModel?.Model;
                if (model != null)
                    m_viewModel?.ChangeSet(new SetDataPresentation(dialog.Data, model.GetThemeDescription(dialog.Data.themeID)), originalData);
            }
        }

        private void OnClickDelete(object sender, RoutedEventArgs e)
        {
            if (m_viewModel?.SelectedItem != null)
            {
                SetDataPresentation data = m_viewModel.SelectedItem.Value;
                m_viewModel?.DeleteSet(data);
            }
        }

        private void OnClickReset(object sender, RoutedEventArgs e)
        {
            m_viewModel?.ResetSets();
        }
        private void OnClickSave(object sender, RoutedEventArgs e)
        {
            m_viewModel?.SaveSets();
        }

    }
}
