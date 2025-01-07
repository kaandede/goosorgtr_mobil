using System.Collections.ObjectModel;
using System.Windows.Input;

namespace goosorgtr_mobil.ViewModels
{
    // Models/User.cs
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Status { get; set; }
        public bool IsOnline { get; set; }
    }

    // ViewModels/NewChatViewModel.cs
    public class NewChatViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                FilterUsers();
            }
        }

        private ObservableCollection<User> _filteredUsers;
        public ObservableCollection<User> FilteredUsers
        {
            get => _filteredUsers;
            set
            {
                _filteredUsers = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectUserCommand { get; }

        public NewChatViewModel()
        {
            LoadSampleUsers();
            SelectUserCommand = new Command<User>(OnUserSelected);
            FilteredUsers = new ObservableCollection<User>(Users);
        }

        private void LoadSampleUsers()
        {
            Users = new ObservableCollection<User>
        {
            new User
            {
                Name = "Mehmet Yılmaz",
                Status = "İşte",
                ProfileImage = "profile1.png",
                IsOnline = true
            },
            new User
            {
                Name = "Zeynep Kaya",
                Status = "Meşgul",
                ProfileImage = "profile2.png",
                IsOnline = false
            },
            new User
            {
                Name = "Ali Demir",
                Status = "Hey! WhatsApp kullanıyorum",
                ProfileImage = "profile3.png",
                IsOnline = true
            }
        };
        }

        private void FilterUsers()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredUsers = new ObservableCollection<User>(Users);
                return;
            }

            var filtered = Users.Where(u =>
                u.Name.ToLower().Contains(SearchQuery.ToLower()));
            FilteredUsers = new ObservableCollection<User>(filtered);
        }

        private async void OnUserSelected(User user)
        {
            // Yeni bir sohbet oluştur
            var newConversation = new ChatConversation
            {
                ContactName = user.Name,
                ProfileImage = user.ProfileImage
            };

            var parameters = new Dictionary<string, object>
        {
            { "ChatId", newConversation.Id }
        };

            await Shell.Current.GoToAsync("//ChatPage", parameters);
        }
    }
  
}
