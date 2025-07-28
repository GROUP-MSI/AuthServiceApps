namespace AuthService.Domain.Entities
{
  public class AppEntity : AuditEntityTemplate
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Certificate { get; set; }

    // References
    public virtual ICollection<UserEntity> Users { get; set; }
    public virtual ICollection<RolEntity> Rols { get; set; }
    public virtual ICollection<PermissionEntity> Permissions { get; set; }
    public virtual ICollection<AppRouteEntity> AppRoutes { get; set; }
    public virtual ICollection<UserLevelEntity> UserLevels { get; set; }
    public virtual ICollection<AppDetailEntity> AppDetails { get; set; }
    public virtual ICollection<EmailCredentials> EmailCredentials { get; set; }

  }  
}