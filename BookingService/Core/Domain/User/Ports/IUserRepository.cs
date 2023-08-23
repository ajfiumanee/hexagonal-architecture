namespace Domain.User.Ports;

public interface IUserRepository
{
    Task<Entities.User> Get(string userName);
}