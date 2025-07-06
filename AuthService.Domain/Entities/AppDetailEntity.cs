namespace AuthService.Domain.Entities
{
  public class AppDetailEntity : AuditEntityTemplate
  {
    public int Id { get; set; }

    public string Value { get; set; }
    
    public int AppId { get; set; }
    public virtual AppEntity App { get; set; }
  }

  public enum AppDetailInfoEnum
  {

  }

  public enum AppDetailDevEnum
  {
    
  } 
}