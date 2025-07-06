namespace AuthService.Domain.Entities
{
  public class PermissionEntity : AuditEntityTemplate
  {

    public int Id { get; set; }

    
    public int AppId { get; set; }
    public virtual AppEntity App { get; set; }
  }  
}