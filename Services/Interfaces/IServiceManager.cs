namespace api.Services.Interfaces
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IQuestionService QuestionService { get; }
        ICommentService CommentService { get; }
    }
}
