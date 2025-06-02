
namespace api.Services
{
    public interface IUserService
    {
        //Task GetAllUsers(UserParameters userParameters, bool trackChanges);
        object GetAllUsers(bool trackChanges);
    }
}