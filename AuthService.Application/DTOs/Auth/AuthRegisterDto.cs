namespace AuthService.Application.DTOs
{
  public class AuthRegisterDto
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string MomFirstName { get; set; }
    public string DadFirstName { get; set; }
    public string MomLastName { get; set; }
    public string DadLastName { get; set; }
    public DateTime BirthDate { get; set; }
  }
}