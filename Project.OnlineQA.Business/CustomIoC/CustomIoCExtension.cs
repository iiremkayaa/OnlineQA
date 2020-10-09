using Microsoft.Extensions.DependencyInjection;
using Project.OnlineQA.Business.Concrete;
using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.DataAccess.Concrete.EfCore.Repository;
using Project.OnlineQA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Business.CustomIoC
{
    public static class CustomIoCExtension
    {
        public  static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ISelectionService, SelectionService>();
            services.AddScoped<ISelectionRepository, SelectionRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSelectionRepository, UserSelectionRepository>();
            services.AddScoped<IUserSelectionService, UserSelectionService>();

        }
    }
}
