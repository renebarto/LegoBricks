using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace LegoBricks.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Model.Model? m_model;

        public MainViewModel(Model.Model model)
        {
            this.Initialize(model);
            PropertyChanged += OnPropertyChanged;
        }

        public void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "BrickCategories":
                    break;
                default:
                    break;
            }
            m_model?.OnPropertyChanged(e.PropertyName);
        }

        private void Initialize(Model.Model model)
        {
            m_model = model;
        }

        public Model.Model? Model
        {
            get { return m_model; }
            set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        }
    }
}
