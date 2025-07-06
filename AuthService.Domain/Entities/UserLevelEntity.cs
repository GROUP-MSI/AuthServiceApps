namespace AuthService.Domain.Entities
{
  public class UserLevelEntity : AuditEntityTemplate
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int AppId { get; set; }
    public virtual AppEntity App { get; set; }

    public virtual ICollection<UserLevelUserEntity> UserLevelUsers { get; set; }
  }  
}