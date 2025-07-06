namespace AuthService.Domain.Entities
{
  public class AuditEntityTemplate
  {
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public int CreatedUserId { get; set; }
    public int UpdatedUserId { get; set; }
    public int DeletedUserId { get; set; }
  }  
}