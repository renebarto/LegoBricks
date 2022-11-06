using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LegoBricks.ViewModel.Commands
{
    public class EditBrickType : ICommand
    {
        #region Fields

        // Member variables
        private readonly BrickTypesViewModel m_viewModel;

        #endregion

        #region Constructor

        public EditBrickType(BrickTypesViewModel viewModel)
        {
            m_viewModel = viewModel;
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// Whether this command can be executed.
        /// </summary>
        public bool CanExecute(object? parameter)
        {
            return (m_viewModel.SelectedItem != null);
        }

        /// <summary>
        /// Fires when the CanExecute status of this command changes.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Invokes this command to perform its intended task.
        /// </summary>
        public void Execute(object? parameter)
        {
            var selectedItem = m_viewModel.SelectedItem;
//                m_viewModel.GroceryList.Remove(selectedItem);
        }

        #endregion
    }
}
