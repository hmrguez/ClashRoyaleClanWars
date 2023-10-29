using Microsoft.Extensions.DependencyInjection;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Common;

class LazilyResolved<T> : Lazy<T>
    where T : notnull
{
    public LazilyResolved(IServiceProvider serviceProvider)
        : base(serviceProvider.GetRequiredService<T>)
    {
    }
}
