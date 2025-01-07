using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace goosorgtr_mobil.ViewModels
{
    public partial class NotificationViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        private ObservableCollection<NotificationItem> notifications;

        [ObservableProperty]
        private ObservableCollection<NotificationItem> filteredNotifications;

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private string currentFilter = "All";

        // Filter button colors
        [ObservableProperty]
        private Color allFilterColor = Colors.Blue;

        [ObservableProperty]
        private Color unreadFilterColor = Colors.Gray;

        [ObservableProperty]
        private Color systemFilterColor = Colors.Gray;

        [ObservableProperty]
        private Color messagesFilterColor = Colors.Gray;

        public NotificationViewModel()
        {
            Notifications = new ObservableCollection<NotificationItem>();
            FilteredNotifications = new ObservableCollection<NotificationItem>();
        }

        [RelayCommand]
        private async Task LoadNotifications()
        {
            try
            {
                // Simulate loading data
                await Task.Delay(1000);

                var sampleData = new List<NotificationItem>
                {
                    new NotificationItem
                    {
                        Id = 1,
                        Title = "Tatil Hakkında Bilgilendirme",
                        Message = "15 Ocak 2025 - 20 Ocak 2025 tarihleri arasında okulumuzda yarıyıl tatili olacaktır. ",
                        TimeAgo = "2 dakika önce",
                        IsUnread = true,
                        Type = "Messages"
                    },
                    new NotificationItem
                    {
                        Id = 2,
                        Title = "Okul Gezisi - Doğa Yürüyüşü",
                        Message = "Okulumuzun 7. sınıf öğrencileri için düzenlediği \"Doğa Yürüyüşü\" etkinliği, 18 Ocak 2025 tarihinde gerçekleştirilecektir. ",
                        TimeAgo = "1 saat önce",
                        IsUnread = false,
                        Type = "System"
                    },
                    new NotificationItem
                    {
                        Id = 3,
                        Title = "Aidat Ödeme Hatırlatması",
                        Message = "Ocak ayına ait okul aidat ödemenizin son günü 15 Ocak 2025’tir. Ödemenizi zamanında gerçekleştirmenizi rica ederiz. Teşekkürler.",
                        TimeAgo = "15 dakika önce",
                        IsUnread = true,
                        Type = "System"
                    },
                    new NotificationItem
                    {
                        Id = 4,
                        Title = "Öğrenci Başarı Bildirimi",
                        Message = "Öğrencimiz Ali Yılmaz, Matematik Olimpiyatları'nda okulumuzu başarıyla temsil ederek ilçe birincisi olmuştur. Öğrencimizin başarılarından dolayı kendisini tebrik eder, destekleriniz için teşekkür ederiz.",
                        TimeAgo = "3 saat önce",
                        IsUnread = false,
                        Type = "Messages"
                    }
                };

                Notifications = new ObservableCollection<NotificationItem>(sampleData);
                await FilterNotifications();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task FilterByType(string filterType)
        {
            CurrentFilter = filterType;

            // Update button colors
            AllFilterColor = filterType == "All" ? Colors.Blue : Colors.Gray;
            UnreadFilterColor = filterType == "Unread" ? Colors.Blue : Colors.Gray;
            SystemFilterColor = filterType == "System" ? Colors.Blue : Colors.Gray;
            MessagesFilterColor = filterType == "Messages" ? Colors.Blue : Colors.Gray;

            await FilterNotifications();
        }

        [RelayCommand]
        private async Task FilterNotifications()
        {
            try
            {
                var filteredList = Notifications.AsEnumerable();

                // Apply type filter
                if (CurrentFilter != "All")
                {
                    filteredList = CurrentFilter == "Unread"
                        ? filteredList.Where(n => n.IsUnread)
                        : filteredList.Where(n => n.Type == CurrentFilter);
                }

                // Apply search filter
                if (!string.IsNullOrWhiteSpace(SearchText))
                {
                    var searchLower = SearchText.ToLower();
                    filteredList = filteredList.Where(n =>
                        n.Title.ToLower().Contains(searchLower) ||
                        n.Message.ToLower().Contains(searchLower));
                }

                FilteredNotifications = new ObservableCollection<NotificationItem>(filteredList);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to filter notifications", "OK");
            }
        }

        [RelayCommand]
        private async Task Refresh()
        {
            IsRefreshing = true;
            await LoadNotifications();
            IsRefreshing = false;
        }

        [RelayCommand]
        private async Task DeleteNotification(NotificationItem notification)
        {
            if (notification == null)
                return;

            var shouldDelete = await Shell.Current.DisplayAlert(
                "Uyarı",
                "Bu bildirimi silmek istediğinizden emin misiniz?",
                "Evet", "Hayır");

            if (shouldDelete)
            {
                Notifications.Remove(notification);
                await FilterNotifications(); // Refresh filtered list
            }
        }
    }

    public partial class NotificationItem : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string message;

        [ObservableProperty]
        private string timeAgo;

        [ObservableProperty]
        private bool isUnread;

        [ObservableProperty]
        private string type;
    }
  
}
