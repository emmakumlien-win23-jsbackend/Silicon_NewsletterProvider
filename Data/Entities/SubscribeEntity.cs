using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class SubscribeEntity
{
    [Key]
    public string Email { get; set; } = null!;
    public bool DailyNewsLetter { get; set; }
    public bool AdvertisingUpdate { get; set; }
    public bool WeekinReview { get; set; }
    public bool EventUpdates { get; set; }
    public bool StartupWeekly { get; set; }
    public bool Podcast { get; set; }
}
