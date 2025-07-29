using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs
{
  public record AuthRequestDto(

    [Required]
    [StringLength(100, MinimumLength = 3)]
    string NameOrGmail,

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial")]
    string Password
  );

  public record AuthRefreshTokenRequestDto(

    [Required]
    string TokenExpired,

    [Required]
    string RefreshToken
  );
}