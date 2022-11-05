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

        private void TabControlDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            m_viewModel = (ViewModel.MainViewModel)this.DataContext;
            if (m_viewModel != null)
            {
                var colorsViewModel = new ColorsViewModel(m_viewModel.Model);
                ColorsPage.DataContext = colorsViewModel;
                var elementsViewModel = new ElementsViewModel(m_viewModel.Model);
                ElementsPage.DataContext = elementsViewModel;
                var partsViewModel = new PartsViewModel(m_viewModel.Model);
                PartsPage.DataContext = partsViewModel;
                var setsViewModel = new SetsViewModel(m_viewModel.Model);
                SetsPage.DataContext = setsViewModel;
                var themesViewModel = new ThemesViewModel(m_viewModel.Model);
                ThemesPage.DataContext = themesViewModel;
                var brickTypesViewModel = new BrickTypesViewModel(m_viewModel.Model);
                BrickTypesPage.DataContext = brickTypesViewModel;
                var brickCategoriesViewModel = new BrickCategoriesViewModel(m_viewModel.Model);
                BrickCategoriesPage.DataContext = brickCategoriesViewModel;
            }
        }

        private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }

        private void ColorsPage_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ColorsPage_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ElementsPage_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ElementsPage_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PartsPage_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PartsPage_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SetsPage_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SetsPage_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ThemesPage_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ThemesPage_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void BrickTypesPage_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void BrickTypesPage_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void BrickCategoriesPage_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void BrickCategoriesPage_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
