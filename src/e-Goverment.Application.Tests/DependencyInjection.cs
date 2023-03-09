using e_Goverment.Application.Tests.Mocks;
using e_Government.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace e_Goverment.Application.Tests
{
    public class DependicsyInjection
    {
        public IServiceProvider ServiceProvider { get; set; }

        public DependicsyInjection()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<IApplicationDbContext, FakeApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("MyCoverment");
            });

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
