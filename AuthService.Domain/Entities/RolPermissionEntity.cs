namespace AuthService.Domain.Entities
{
  public class RolPermissionEntity : AuditEntityTemplate
  {
    public int Id { get; set; }
    public int RolId { get; set; }
    public int PermissionId { get; set; }
    public virtual RolEntity Rol { get; set; }
    public virtual PermissionEntity Permission { get; set; }
  }  
}