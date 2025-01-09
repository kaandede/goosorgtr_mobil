using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace goosorgtr_mobil.ViewModels
{

    // Models/ChatMessage.cs
    public class ChatMessage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string SenderId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsMine { get; set; }
    }

    // Models/ChatConversation.cs
    public class ChatConversation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ContactName { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastMessageTime { get; set; }
        public string ProfileImage { get; set; }
        public bool HasUnreadMessages { get; set; }
    }



    // ViewModels/ChatListViewModel.cs
    public partial class MesajlasmaViewModel : BaseViewModel
    {
        private ObservableCollection<ChatConversation> _conversations;
        public ObservableCollection<ChatConversation> Conversations
        {
            get => _conversations;
            set
            {
                _conversations = value;
                OnPropertyChanged();
            }
        }



        public MesajlasmaViewModel()
        {
            LoadSampleData();

        }

        private void LoadSampleData()
        {
            Conversations = new ObservableCollection<ChatConversation>
        {
            new ChatConversation
            {
                ContactName = "Ahmet Yılmaz",
                LastMessage = "Yarın görüşelim mi?",
                LastMessageTime = DateTime.Now.AddHours(-1),
                ProfileImage = "profile1.png",
                HasUnreadMessages = true
            },
            new ChatConversation
            {
                ContactName = "Ayşe Demir",
                LastMessage = "Toplantı notlarını aldım",
                LastMessageTime = DateTime.Now.AddHours(-3),
                ProfileImage = "profile2.png",
                HasUnreadMessages = false
            }
        };
        }

        [RelayCommand]
        public async void OnNewChat()
        {
            await Shell.Current.GoToAsync("NewChatPage");
        }

        [RelayCommand]
        public async void OnOpenChat(ChatConversation conversation)
        {
            var parameters = new Dictionary<string, object>
        {
            { "ChatId", conversation.Id }
        };
            await Shell.Current.GoToAsync("ChatPage", parameters);
        }
    }

    // ViewModels/ChatViewModel.cs
    public class MesajViewModel : BaseViewModel
    {
        private ObservableCollection<ChatMessage> _messages;
        public ObservableCollection<ChatMessage> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }

        private string _newMessage;
        public string NewMessage
        {
            get => _newMessage;
            set
            {
                _newMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendMessageCommand { get; }

        public MesajViewModel()
        {
            Messages = new ObservableCollection<ChatMessage>();
            SendMessageCommand = new Command(OnSendMessage);
            LoadSampleMessages();
        }

        private void LoadSampleMessages()
        {
            Messages = new ObservableCollection<ChatMessage>
        {
            new ChatMessage
            {
                Content = "Merhaba, nasılsın?",
                Timestamp = DateTime.Now.AddMinutes(-30),
                IsMine = false
            },
            new ChatMessage
            {
                Content = "İyiyim, teşekkürler. Sen nasılsın?",
                Timestamp = DateTime.Now.AddMinutes(-29),
                IsMine = true
            }
        };
        }

        private void OnSendMessage()
        {
            if (string.IsNullOrWhiteSpace(NewMessage))
                return;

            Messages.Add(new ChatMessage
            {
                Content = NewMessage,
                Timestamp = DateTime.Now,
                IsMine = true
            });

            NewMessage = string.Empty;
        }
    }
}
