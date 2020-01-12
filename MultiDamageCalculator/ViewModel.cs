using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDamageCalculator
{
    public class ViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int calcoliInMemoria = 0;

        public int CalcoliInMemoria
        {
            get => calcoliInMemoria;

            set
            {
                if(calcoliInMemoria == value)
                {
                    return;
                }

                calcoliInMemoria = value;

                OnPropertyChanged(nameof(CalcoliInMemoria));
            }
        }
    }
}
