using api.Repository;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using api.Models;

namespace api.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IQuestionService> _questionService;
        private readonly Lazy<ICommentService> _commentService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper,
            UserManager<User> userManager,
            IQuestionService questionService,
            ICommentService commentService
            )
        {
            _userService = new Lazy<IUserService>(() =>
                new UserService(repositoryManager, logger, mapper, userManager));

            _questionService = new Lazy<IQuestionService>(() =>
                questionService);

            _commentService = new Lazy<ICommentService>(() =>
                commentService);
        }
    
        public IUserService UserService => _userService.Value;
        public IQuestionService QuestionService => _questionService.Value;
        public ICommentService CommentService => _commentService.Value;
    }
}
