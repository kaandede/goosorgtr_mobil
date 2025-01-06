using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace goosorgtr_mobil.ViewModels
{


    public partial class NotificationSettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isPushNotificationsEnabled;

        [ObservableProperty]
        private bool isEmailNotificationsEnabled;

        [ObservableProperty]
        private bool isNewsNotificationsEnabled;

        [ObservableProperty]
        private bool isPromotionsEnabled;

        [ObservableProperty]
        private bool isAccountActivityEnabled;

        private readonly INotificationService _notificationService;
        private readonly IPreferencesService _preferencesService;

        public NotificationSettingsViewModel(
            INotificationService notificationService,
            IPreferencesService preferencesService)
        {
            _notificationService = notificationService;
            _preferencesService = preferencesService;
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Load saved preferences
            IsPushNotificationsEnabled = _preferencesService.Get(nameof(IsPushNotificationsEnabled), true);
            IsEmailNotificationsEnabled = _preferencesService.Get(nameof(IsEmailNotificationsEnabled), true);
            IsNewsNotificationsEnabled = _preferencesService.Get(nameof(IsNewsNotificationsEnabled), true);
            IsPromotionsEnabled = _preferencesService.Get(nameof(IsPromotionsEnabled), false);
            IsAccountActivityEnabled = _preferencesService.Get(nameof(IsAccountActivityEnabled), true);
        }

        [RelayCommand]
        private async Task SaveAsync()
        {
            try
            {
                // Save to preferences
                _preferencesService.Set(nameof(IsPushNotificationsEnabled), IsPushNotificationsEnabled);
                _preferencesService.Set(nameof(IsEmailNotificationsEnabled), IsEmailNotificationsEnabled);
                _preferencesService.Set(nameof(IsNewsNotificationsEnabled), IsNewsNotificationsEnabled);
                _preferencesService.Set(nameof(IsPromotionsEnabled), IsPromotionsEnabled);
                _preferencesService.Set(nameof(IsAccountActivityEnabled), IsAccountActivityEnabled);

                // Update notification settings on the server
                await _notificationService.UpdateSettingsAsync(new NotificationSettings
                {
                    PushEnabled = IsPushNotificationsEnabled,
                    EmailEnabled = IsEmailNotificationsEnabled,
                    NewsEnabled = IsNewsNotificationsEnabled,
                    PromotionsEnabled = IsPromotionsEnabled,
                    AccountActivityEnabled = IsAccountActivityEnabled
                });

                await Shell.Current.DisplayAlert("Success", "Settings saved successfully", "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to save settings", "OK");
            }
        }
    }

    // NotificationSettings.cs
    public class NotificationSettings
    {
        public bool PushEnabled { get; set; }
        public bool EmailEnabled { get; set; }
        public bool NewsEnabled { get; set; }
        public bool PromotionsEnabled { get; set; }
        public bool AccountActivityEnabled { get; set; }
    }

    // INotificationService.cs
    public interface INotificationService
    {
        Task UpdateSettingsAsync(NotificationSettings settings);
    }

    public class NotificationService : INotificationService
    {
        public Task UpdateSettingsAsync(NotificationSettings settings)
        {
           return Task.CompletedTask;
        }
    }
    public class PreferencesService : IPreferencesService
    {
        public T Get<T>(string key, T defaultValue)
        {
            return defaultValue;
            //throw new NotImplementedException();
        }

        public void Set<T>(string key, T value)
        {
          
        }
    }

    // IPreferencesService.cs
    public interface IPreferencesService
    {
        T Get<T>(string key, T defaultValue);
        void Set<T>(string key, T value);
    }
}