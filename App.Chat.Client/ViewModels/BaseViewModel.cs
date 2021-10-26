using System.ComponentModel;

namespace App.Chat.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Esse evento é disparado todas vez que uma classe filho tem o valor de sua propriedade alterado.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Chame esse método para disparar o evento da <see cref="PropertyChanged"/>
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name) =>
            PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
}