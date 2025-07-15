using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Database
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<AppDetailEntity> AppDetails { get; set; }
    public DbSet<AppEntity> Apps { get; set; }
    public DbSet<AppRouteEntity> AppRoutes { get; set; }
    public DbSet<LogLoginEntity> LogLogins { get; set; }
    public DbSet<NotificationEntity> Notifications { get; set; }
    public DbSet<PermissionAppRouteEntity> PermissionAppRoutes { get; set; }
    public DbSet<PermissionEntity> Permissions { get; set; }
    public DbSet<RolEntity> Rols { get; set; }
    public DbSet<RolPermissionEntity> RolPermissions { get; set; }
    public DbSet<RolUserEntity> RolUsers { get; set; }
    public DbSet<TokenEntity> Tokens { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserInfoEntity> UserInfos { get; set; }
    public DbSet<UserLevelEntity> UserLevels { get; set; }
    public DbSet<UserLevelUserEntity> UserLevelUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<AppDetailEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.App)
          .WithMany(p => p.AppDetails)
          .HasForeignKey(p => p.AppId)
          .IsRequired();
      });

      modelBuilder.Entity<AppRouteEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.App)
          .WithMany(p => p.AppRoutes)
          .HasForeignKey(p => p.AppId)
          .IsRequired();
      });

      modelBuilder.Entity<LogLoginEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.User)
          .WithMany(p => p.LogLogins)
          .HasForeignKey(p => p.UserId)
          .IsRequired();
      });

      modelBuilder.Entity<NotificationEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.User)
          .WithMany(p => p.Notifications)
          .HasForeignKey(p => p.UserId)
          .IsRequired();
      });

      modelBuilder.Entity<PermissionAppRouteEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.Permission)
          .WithMany(p => p.PermissionAppRoutes)
          .HasForeignKey(p => p.PermssionId)
          .IsRequired();

        tb.HasOne(p => p.AppRoute)
          .WithMany(p => p.PermissionAppRoutes)
          .HasForeignKey(p => p.AppRouteId)
          .IsRequired();
      });

      modelBuilder.Entity<PermissionEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.App)
          .WithMany(p => p.Permissions)
          .HasForeignKey(p => p.AppId)
          .IsRequired();
      });

      modelBuilder.Entity<RolEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.App)
          .WithMany(p => p.Rols)
          .HasForeignKey(p => p.AppId)
          .IsRequired();
      });

      modelBuilder.Entity<RolPermissionEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.Rol)
          .WithMany(p => p.RolPermissions)
          .HasForeignKey(p => p.RolId)
          .IsRequired();

        tb.HasOne(p => p.Permission)
          .WithMany(p => p.RolPermissions)
          .HasForeignKey(p => p.PermissionId)
          .IsRequired();
      });

      modelBuilder.Entity<RolUserEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.Rol)
          .WithMany(p => p.RolUsers)
          .HasForeignKey(p => p.RolId)
          .IsRequired();

        tb.HasOne(p => p.User)
          .WithMany(p => p.RolUsers)
          .HasForeignKey(p => p.UserId)
          .IsRequired();
      });

      modelBuilder.Entity<UserEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.App)
          .WithMany(p => p.Users)
          .HasForeignKey(p => p.AppId)
          .IsRequired();
      });

      modelBuilder.Entity<UserInfoEntity>(tb =>
      {
        tb.HasKey(a => a.Id);
        tb.HasOne(p => p.User)
          .WithOne(p => p.UserInfo)
          .HasForeignKey<UserInfoEntity>(p => p.Id);
      });

      modelBuilder.Entity<UserLevelEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.App)
          .WithMany(p => p.UserLevels)
          .HasForeignKey(p => p.AppId)
          .IsRequired();
      });

      modelBuilder.Entity<UserLevelUserEntity>(tb =>
      {
        tb.HasKey(a => a.Id);

        tb.HasOne(p => p.UserLevel)
          .WithMany(p => p.UserLevelUsers)
          .HasForeignKey(p => p.UserLevelId)
          .IsRequired();

        tb.HasOne(p => p.User)
          .WithMany(p => p.UserLevelUsers)
          .HasForeignKey(p => p.UserId)
          .IsRequired();
      });
      
    }
  }
}