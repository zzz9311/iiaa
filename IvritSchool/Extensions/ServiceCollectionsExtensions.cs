using IvritSchool.BLL.Days;
using IvritSchool.BLL.Messages;
using IvritSchool.BLL.PayedUsers;
using IvritSchool.BLL.SendersLogic;
using IvritSchool.BLL.Tariffs;
using IvritSchool.BLL.Users;
using IvritSchool.Commands;
using IvritSchool.Data;
using IvritSchool.Finder;
using IvritSchool.Repository;
using IvritSchool.Senders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace IvritSchool.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            services.AddCommands();

            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<IDayBLL, DayBLL>();
            services.AddScoped<ITariffBLL, TariffBLL>();
            services.AddScoped<IMessageBLL, MessageBLL>();
            services.AddScoped<ISender, Sender>();
            services.AddScoped<ILessonSenderBLL, LessonSenderBLL>();
            services.AddScoped<IPayedUser, PayedUser>();

            return services;
        }

        public static IServiceCollection AddDAL(this IServiceCollection services)
        {
            services.AddScoped(typeof(IFinder<>), typeof(Finder<>));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<ISaveChangesCommand>(options => options.GetService<ApplicationDbContext>());

            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            foreach (Type type in
                             Assembly.GetAssembly(typeof(Command)).GetTypes()
                             .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Command))))
            {
                services.AddScoped(typeof(Command), type);
            }
            return services;
        }
    }
}
