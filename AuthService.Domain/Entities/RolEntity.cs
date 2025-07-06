namespace AuthService.Domain.Entities
{
  public class RolEntity : AuditEntityTemplate
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public int AppId { get; set; }
    public virtual AppEntity App { get; set; }

    public virtual ICollection<RolPermissionEntity> RolPermissions { get; set; }
    public virtual ICollection<RolUserEntity> RolUsers { get; set; }
  }  
}