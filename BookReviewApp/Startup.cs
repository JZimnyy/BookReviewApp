using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookReviewApp.Startup))]
namespace BookReviewApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
