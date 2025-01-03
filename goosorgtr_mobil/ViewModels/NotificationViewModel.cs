using goosorgtr_mobil.Models;

namespace goosorgtr_mobil.ViewModels
{
    public class NotificationViewModel
    {
        public List<NotificationItem> Data { get; }

        public NotificationViewModel()
        {
            Data = new List<NotificationItem>() {
                new NotificationItem("Prepare Financial"),
                new NotificationItem("Prepare Marketing Plan"),
                new NotificationItem("QA Strategy Report"),
                new NotificationItem("Update Personnel Files"),
                new NotificationItem("Provide New Health Insurance Docs"),
                new NotificationItem("Choose between PPO and HMO Health Plan"),
                new NotificationItem("New Brochures"),
                new NotificationItem("Brochure Designs"),
                new NotificationItem("Brochure Design Review"),
                new NotificationItem("Create Sales Report"),
                new NotificationItem("Deliver R&D Plans"),
            };
        }
    }
}
