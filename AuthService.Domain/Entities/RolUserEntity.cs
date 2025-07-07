namespace AuthService.Domain.Entities
{
  public class RolUserEntity : AuditEntityTemplate
  {
    public int Id { get; set; }
    public int RolId { get; set; }
    public int UserId { get; set; }
    public virtual UserEntity User { get; set; }
    public virtual RolEntity Rol { get; set; }
  }
}