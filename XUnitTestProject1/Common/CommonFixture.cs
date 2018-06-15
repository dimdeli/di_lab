using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace XUnitTestProject1.Common
{
    public class CommonFixture : IDisposable
    {
        private IServiceProvider container_;

        public CommonFixture()
        {
            container_ = new ServiceCollection()
                .AddSingleton<IPricingService, PricingService>()
                .BuildServiceProvider();
        }

        public T Resolve<T>()
        {
            return container_.GetService<T>();
        }

        public virtual void Dispose()
        {
            //clean up...
        }
    }
}
