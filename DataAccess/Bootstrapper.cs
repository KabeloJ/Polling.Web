using Core.Answer.DataAccess;
using DataAccess.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess
{
    public static class Bootstrapper
    {
        public static string ConnectionString { get; set; }
        public static void AddDataAccess(this IServiceCollection service, IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("DefaultConnection");
            service.AddSingleton<IAnswerDataAccess, AnswerDataAccess>();
            service.AddSingleton<PollDataAccess>();
            service.AddSingleton<QuestionDataAccess>();
            service.AddSingleton<OptionDataAccess>();
        }

    }
}
