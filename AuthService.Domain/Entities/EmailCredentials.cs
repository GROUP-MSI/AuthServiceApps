namespace AuthService.Domain.Entities
{
  public class EmailCredentials : AuditEntityTemplate
  {
    public int Id { get; set; }
    public string Server { get; set; }
    public int Port { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public int AppId { get; set; }
    public virtual AppEntity App { get; set; }
  }
}