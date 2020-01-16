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

        private int calcsInMemory = 0;

        public int CalcsInMemory
        {
            get => calcsInMemory;

            set
            {
                if(calcsInMemory == value)
                {
                    return;
                }

                calcsInMemory = value;

                OnPropertyChanged(nameof(CalcsInMemory));
            }
        }
    }
}
