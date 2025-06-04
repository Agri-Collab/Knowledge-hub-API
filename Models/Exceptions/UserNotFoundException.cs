namespace api.Models.Exceptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int id) : base($"The user with id: {id} does not exist in the database.")
        {

        }
    }
}