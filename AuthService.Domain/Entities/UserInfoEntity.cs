namespace AuthService.Domain.Entities
{
  public class UserInfoEntity : AuditEntityTemplate
  {
    public int Id { get; set; }
    public string DadFirstName { get; set; }
    public string MomFirstName { get; set; }
    public string DadLastName { get; set; }
    public string MomLastName { get; set; }
    public DateTime Birthday { get; set; }

    public virtual UserEntity User { get; set; }
  }  
}