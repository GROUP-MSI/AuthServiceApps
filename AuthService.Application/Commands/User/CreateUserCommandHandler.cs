using AuthService.Domain.Repositories;
using MediatR;

namespace AuthService.Application.Commands
{
  public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
  {
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    // public async Task<Guid> Handle(CreateUserCommand request, CancellationToken ct)
    // {
    //   await _userRepository.CreateUser(user);
    //   return user.Id;
    // }
  }
}