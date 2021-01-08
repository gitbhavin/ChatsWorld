using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatsWorld
{
    /// <summary>
    /// Command That run an Action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Member
        /// <summary>
        /// Action to run
        /// </summary>

        private readonly Action mAction;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            this.mAction = action;
        }

        #endregion

        #region Public Event
        /// <summary>
        /// Event that fire <see cref="CanExecute"/> value change
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Command Method
        /// <summary>
        /// Relay Command Can always Execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute the command Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }
        #endregion
    }
}
