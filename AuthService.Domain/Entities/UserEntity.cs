namespace AuthService.Domain.Entities
{
  public class UserEntity : AuditEntityTemplate
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public Guid PasswordSalt { get; set; }
    public string Email { get; set; }
    public int AppId { get; set; }
    public virtual AppEntity App { get; set; }

    public virtual UserInfoEntity UserInfo { get; set; }
    public virtual ICollection<UserLevelUserEntity> UserLevelUsers { get; set; }
    public virtual ICollection<NotificationEntity> Notifications { get; set; }
    public virtual ICollection<RolUserEntity> RolUsers { get; set; }
    public virtual ICollection<LogLoginEntity> LogLogins { get; set; }
    public virtual ICollection<TokenEntity> Tokens { get; set; }
  }
}