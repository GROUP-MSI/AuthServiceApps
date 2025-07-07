namespace AuthService.Domain.Entities
{
  public class PermissionAppRouteEntity : AuditEntityTemplate
  {
    public int Id { get; set; }
    public int AppRouteId { get; set; }
    public int PermssionId { get; set; }
    public virtual AppRouteEntity AppRoute { get; set; }
    public virtual PermissionEntity Permission { get; set; }
  }
}