using AuthService.Application.Helpers;
using AuthService.Domain.Entities;
using AuthService.Domain.Repositories;
using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Options;

namespace AuthService.Application.Commands
{
  public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
  {
    private readonly IUserRepository _userRepo;
    private readonly IBaseRepository _trepo;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(
      IUserRepository userRepo,
      IBaseRepository trepo,
      IMapper mapper)
    {
      _userRepo = userRepo;
      _trepo = trepo;
      _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

      try
      {
        var uniquenessCheck = await CheckUserUniquenessAsync(request.Name, request.Email, request.AppId, cancellationToken);
        if (uniquenessCheck.IsFailed)
          return Result.Fail<int>(uniquenessCheck.Errors);

        Guid salt = Guid.NewGuid();
        var userCreate = _mapper.Map<UserEntity>(request);
        userCreate.Password = PasswordHashSecurity.HashPassword(request.Password, salt);

        await _userRepo.CreateUser(userCreate, salt);

        return Result.Ok(userCreate.Id);
      }
      catch (Exception err)
      {
        Console.WriteLine(err.StackTrace);
        return Result.Fail<int>($"Error al crear usuario: {err.Message}");
      }
    }

    public async Task<Result> CheckUserUniquenessAsync(string name, string email, int appId, CancellationToken cancellationToken)
    {
      var existingUser = await _trepo.FindByConditionAsync<UserEntity>(u =>
          u.AppId == appId &&
          (u.Name == name || u.Email == email),
          cancellationToken);

      if (existingUser?.Name == name)
        return Result.Fail("Ya existe un usuario con este nombre en la aplicación");

      if (existingUser?.Email == email)
        return Result.Fail("Ya existe un usuario con este email en la aplicación");

      return Result.Ok();
    }
  }
}