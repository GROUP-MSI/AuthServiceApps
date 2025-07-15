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
    public string Photo { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Ci { get; set; }
    public string Address { get; set; }

    public virtual UserEntity User { get; set; }
  }  
}