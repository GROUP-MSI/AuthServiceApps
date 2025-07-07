namespace AuthService.Domain.Entities
{
  public class AppRouteEntity : AuditEntityTemplate
  {

    public int Id { get; set; }
    public string Description { get; set; }
    public string Route { get; set; }
    public int AppId { get; set; }
    public virtual AppEntity App { get; set; }
    public virtual ICollection<PermissionAppRouteEntity> PermissionAppRoutes { get; set; }
  }  
}