using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace RGB_Background {
    public class BoundProperties : INotifyPropertyChanged {

        private bool _RGB;
        private Brush _Background;

        public bool RGB { get => _RGB; set => SetProperty(ref _RGB, value); }
        public Brush Background { get => _Background; set => SetProperty(ref _Background, value); }

        public BoundProperties() {
            RGB = false;

            BrushConverter bc = new();
            Background = (Brush)bc.ConvertFrom("#ffe0e0e0");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "") {
            if (EqualityComparer<T>.Default.Equals(storage, value)) {
                return;
            }
            storage = value;
            OnPropertyChanged(propertyName);
        }
    }
}
