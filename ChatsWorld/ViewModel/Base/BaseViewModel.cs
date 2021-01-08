using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatsWorld
{

    /// <summary>
    /// Basic ViewModel that fires Property change event as nedded
    /// </summary>
    // [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// the event that fires when any child property changed its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };


        /// <summary>
        /// call this to fire<see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
