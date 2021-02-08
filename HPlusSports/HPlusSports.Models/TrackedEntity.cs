using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HPlusSports.Models
{
    public class TrackedEntity : Entity, INotifyPropertyChanged
    {
        public bool Deleted { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        internal T NotifyIfChanged<T>(T fieldValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (!fieldValue?.Equals(newValue) ?? true)
            {
                fieldValue = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            return newValue;
        }
    }
}
