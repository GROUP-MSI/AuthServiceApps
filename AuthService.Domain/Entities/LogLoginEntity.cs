namespace AuthService.Domain.Entities
{
  public class LogLoginEntity
  {
    public int Id { get; set; }
    public bool NameCorrect { get; set; }
    public bool PassCorrect { get; set; }
    public DateTime LoginDate { get; set; }
    public int UserId { get; set; }
    public virtual UserEntity User { get; set; }
  }  
}