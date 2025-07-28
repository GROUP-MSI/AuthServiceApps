using AuthService.Domain.Repositories;
using MediatR;

namespace AuthService.Application.Commands
{
  public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
  {
    private readonly IUserRepository _repo;

    public CreateUserCommandHandler(IUserRepository repo)
    {
      _repo = repo;
    }

    public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    // public async Task<Guid> Handle(CreateUserCommand request, CancellationToken ct)
    // {
    //   await _repo.CreateUser(user);
    //   return user.Id;
    // }
  }
}