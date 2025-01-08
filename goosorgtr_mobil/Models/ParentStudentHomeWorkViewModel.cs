using System.Collections.ObjectModel;
using System.ComponentModel;

namespace goosorgtr_mobil.Models
{
    public class ParentStudentHomeWorkViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Ders> Dersler { get; set; } = new();

        public ParentStudentHomeWorkViewModel()
        {
            Dersler = new ObservableCollection<Ders>
            {
                new Ders { Adi = "Matematik" },
                new Ders { Adi = "Fen Bilgisi" },
                new Ders { Adi = "İngilizce" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Ders : INotifyPropertyChanged
    {
        public string? Adi { get; set; }

        private bool isExpanded;
        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                if (isExpanded != value)
                {
                    isExpanded = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsExpanded)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
