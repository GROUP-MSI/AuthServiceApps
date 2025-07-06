namespace AuthService.Domain.Entities
{
  public class UserLevelUserEntity : AuditEntityTemplate
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int UserLevelId { get; set; }

    public virtual UserEntity User { get; set; }
    public virtual UserLevelEntity UserLevel { get; set; }
  }  
}