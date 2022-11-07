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
    public partial class ThemesPage : TabItem
    {
        private ViewModel.ThemesViewModel? m_viewModel;

        public ThemesPage()
        {
            InitializeComponent();
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            m_viewModel = (ViewModel.ThemesViewModel)this.DataContext;
        }

        private void OnClickAdd(object sender, RoutedEventArgs e)
        {
            var dialog = new ThemeEditForm();
            dialog.Title = "Add Theme";
            ThemeEditViewModel viewModel = new ThemeEditViewModel(m_viewModel?.Model, true);
            dialog.DataContext = viewModel;
            if (m_viewModel?.SelectedItem != null)
            {
                ThemeDataPresentation data = m_viewModel.SelectedItem.Value;
                dialog.Data = data.data;
            }
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var model = m_viewModel?.Model;
                if (model != null)
                    m_viewModel?.AddTheme(new ThemeDataPresentation(dialog.Data, model.GetThemeDescription(dialog.Data.ParentID)));
            }
        }

        private void OnClickEdit(object sender, RoutedEventArgs e)
        {
            var originalData = new ThemeDataPresentation();
            var dialog = new ThemeEditForm();
            dialog.Title = "Edit Theme";
            ThemeEditViewModel viewModel = new ThemeEditViewModel(m_viewModel?.Model, false);
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
                    m_viewModel?.ChangeTheme(new ThemeDataPresentation(dialog.Data, model.GetThemeDescription(dialog.Data.ParentID)), originalData);
            }
        }

        private void OnClickDelete(object sender, RoutedEventArgs e)
        {
            if (m_viewModel?.SelectedItem != null)
            {
                ThemeDataPresentation data = m_viewModel.SelectedItem.Value;
                m_viewModel?.DeleteTheme(data);
            }
        }

        private void OnClickReset(object sender, RoutedEventArgs e)
        {
            m_viewModel?.ResetThemes();
        }
        private void OnClickSave(object sender, RoutedEventArgs e)
        {
            m_viewModel?.SaveThemes();
        }
    }
}
