using LegoBricks.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace LegoBricks.ViewModel
{
    public class BrickCategoryEditViewModel : ViewModelBase
    {
        private bool m_checkExisting;
        private Model.Model? m_model;
        private string? m_id;
        private string? m_name;

        public BrickCategoryEditViewModel(Model.Model? model, bool checkExisting)
        {
            m_model = model;
            m_checkExisting = checkExisting;
        }

        public String BrickCategoryID
        {
            get { return m_id ?? ""; }
            set { m_id = value; base.RaisePropertyChangedEvent("BrickCategoryID"); }
        }
        public String BrickCategoryName
        {
            get { return m_name ?? ""; }
            set { m_name = value; base.RaisePropertyChangedEvent("BrickCategoryName"); }
        }

        public bool CheckExisting
        {
            get { return m_checkExisting; }
        }
        public Model.Model? Model
        {
            get { return m_model; }
            set { m_model = value; base.RaisePropertyChangedEvent("Model"); }
        }
    }
}
