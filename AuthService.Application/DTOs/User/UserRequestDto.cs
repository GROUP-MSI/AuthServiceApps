namespace AuthService.Application.DTOs
{
  public record RegisterUserRequestDto(
    string Name,
    string Password,
    string Email,
    string DadFirstName,
    string MomFirstName,
    string DadLastName,
    string MomLastName,
    DateTime BirthDay,
    string Ci);
}