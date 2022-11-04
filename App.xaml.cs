using LegoBricks.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LegoBricks
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var database = new Model.Database();
            var model = new Model.Model(database);
            var viewModel = new ViewModel.MainViewModel(model);
            var mainWindow = new View.MainWindow();
            mainWindow.DataContext = viewModel;
            mainWindow.Show();
        }
    }
}
