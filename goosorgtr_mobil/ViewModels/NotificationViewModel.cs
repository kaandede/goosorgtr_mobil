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
                        Title = "New Message",
                        Message = "You have received a new message from John",
                        TimeAgo = "2 minutes ago",
                        IsUnread = true,
                        Type = "Messages"
                    },
                    new NotificationItem
                    {
                        Id = 2,
                        Title = "System Update",
                        Message = "A new version of the app is available",
                        TimeAgo = "1 hour ago",
                        IsUnread = false,
                        Type = "System"
                    },
                    new NotificationItem
                    {
                        Id = 3,
                        Title = "Reminder",
                        Message = "Your meeting starts in 15 minutes",
                        TimeAgo = "15 minutes ago",
                        IsUnread = true,
                        Type = "System"
                    },
                    new NotificationItem
                    {
                        Id = 4,
                        Title = "Message from Support",
                        Message = "Your ticket has been resolved",
                        TimeAgo = "3 hours ago",
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
                "Delete Notification",
                "Are you sure you want to delete this notification?",
                "Yes", "No");

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
