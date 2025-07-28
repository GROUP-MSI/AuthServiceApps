using AuthService.Application.Helpers;
using AuthService.Domain.Entities;
using AuthService.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;

namespace AuthService.Application.Commands
{
  public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserEntity>
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

    public async Task<UserEntity> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      Guid salt = Guid.NewGuid();
      var userCreate = _mapper.Map<UserEntity>(request);
      userCreate.Password = PasswordHashSecurity.HashPassword(request.Password, salt);
      userCreate.AppId = 4;

      var userInfoCreate = _mapper.Map<UserInfoEntity>(request);
      var user = await _userRepo.CreateUser(userCreate, salt);

      userInfoCreate.Id = user.Id;
      await _trepo.Create(userInfoCreate);
      return user;
    }
  }
}