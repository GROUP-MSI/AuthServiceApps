namespace AuthService.Domain.Entities
{
  public class NotificationEntity
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }

  }  
}