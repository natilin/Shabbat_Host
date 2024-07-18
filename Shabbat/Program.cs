using Microsoft.Extensions.Configuration;
using Shabbat.DAL;
using Shabbat.DAL.Repositories;

namespace Shabbat
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            string? conn = config["ConnectionString"];
            DBContext dbCtx = new DBContext(conn);


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Form form = new HostForm(new CategoryRepository(dbCtx));
            form.Show();
            Application.Run();
        }
    }
}