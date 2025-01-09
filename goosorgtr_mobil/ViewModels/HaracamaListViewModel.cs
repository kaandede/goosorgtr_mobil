using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace goosorgtr_mobil.ViewModels
{
    public class ExpenseItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount => Quantity * Price;
    }

    public class HarcamaListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ExpenseItem> _expenses;
        private DateTime _selectedDate = DateTime.Today;
        private decimal _dailyTotalAmount;

        public ObservableCollection<ExpenseItem> Expenses
        {
            get => _expenses;
            set
            {
                _expenses = value;
                OnPropertyChanged(nameof(Expenses));
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                FilterExpenses();
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        public decimal DailyTotalAmount
        {
            get => _dailyTotalAmount;
            set
            {
                _dailyTotalAmount = value;
                OnPropertyChanged(nameof(DailyTotalAmount));
            }
        }

        private ObservableCollection<ExpenseItem> _allExpenses;

        public ICommand FilterCommand { get; }

        public HarcamaListViewModel()
        {
            _allExpenses = new ObservableCollection<ExpenseItem>
            {
                new ExpenseItem { ProductName = "Çikolata", Quantity = 2, Price = 7.5M, PurchaseDate = DateTime.Now.AddDays(-1) },
                new ExpenseItem { ProductName = "Süt", Quantity = 1, Price = 25M, PurchaseDate = DateTime.Now },
                new ExpenseItem { ProductName = "Karışık Tost", Quantity = 1, Price = 100M, PurchaseDate = DateTime.Now },
                new ExpenseItem { ProductName = "Ayran", Quantity = 1, Price = 20M, PurchaseDate = DateTime.Now.AddDays(-2) }
            };

            Expenses = new ObservableCollection<ExpenseItem>(_allExpenses);
            FilterCommand = new Command(FilterExpenses);
            CalculateDailyTotal();
        }

        private void FilterExpenses()
        {
            var filteredItems = _allExpenses.Where(e =>
                e.PurchaseDate.Date == SelectedDate.Date).ToList();

            Expenses.Clear();
            foreach (var item in filteredItems)
            {
                Expenses.Add(item);
            }

            CalculateDailyTotal();
        }

        private void CalculateDailyTotal()
        {
            DailyTotalAmount = Expenses.Sum(e => e.TotalAmount);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
