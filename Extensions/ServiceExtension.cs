using api.Data;
using api.Repository;
using api.Services;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
                
            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IPrivateChatRepository, PrivateChatRepository>();
            services.AddScoped<IPrivateMessageRepository, PrivateMessageRepository>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IPrivateChatService, PrivateChatService>();
            services.AddScoped<IPrivateMessageService, PrivateMessageService>();

            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<DataContext>(opts =>
                opts.UseNpgsql(configuration.GetConnectionString("sqlConnection")));
    }
}
