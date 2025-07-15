namespace AuthService.Domain.Entities
{
  public class TokenEntity
  {
    public int Id { get; set; }
    public string CurrentToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime CurrentTime { get; set; }
    public DateTime ExpirateDate { get; set; }
    public bool Active { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }

  }  
}