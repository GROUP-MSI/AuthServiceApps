using AuthService.Domain.Enums;

namespace AuthService.Domain.Entities
{
  public class PermissionEntity : AuditEntityTemplate
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public PermissionEnum Type { get; set; }
    public int AppId { get; set; }
    public virtual AppEntity App { get; set; }
    public virtual ICollection<PermissionAppRouteEntity> PermissionAppRoutes { get; set; }
    public virtual ICollection<RolPermissionEntity> RolPermissions { get; set; }
  }
}