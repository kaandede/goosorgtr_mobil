using System.ComponentModel;
using System.Windows.Input;

namespace goosorgtr_mobil.Models
{

    public class NotificationItem : INotifyPropertyChanged
    {
        public NotificationItem(string description)
        {
            ChangeStateCommand = new Command(() => IsTaskCompleted = !IsTaskCompleted);
            Description = description;
            UpdateState();
        }

        public string Description { get; private set; }

        bool isTaskCompleted;
        public bool IsTaskCompleted
        {
            get => isTaskCompleted;
            set
            {
                isTaskCompleted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsTaskCompleted)));
                UpdateState();
            }
        }

        Color itemColor;
        public Color ItemColor
        {
            get => itemColor;
            private set
            {
                itemColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemColor)));
            }
        }

        string actionText;
        public string ActionText
        {
            get => actionText;
            private set
            {
                actionText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActionText)));
            }
        }

        string actionIcon;
        public string ActionIcon
        {
            get => actionIcon;
            private set
            {
                actionIcon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActionIcon)));
            }
        }

        public ICommand ChangeStateCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

    
        void UpdateState()
        {
            ItemColor = IsTaskCompleted ? Color.FromArgb("#c6eccb") : Color.FromArgb("#e6e6e6");
            ActionText = IsTaskCompleted ? "To Do" : "Done";
            ActionIcon = IsTaskCompleted ? "uncompletetask" : "completetask";
        }
    }
}

