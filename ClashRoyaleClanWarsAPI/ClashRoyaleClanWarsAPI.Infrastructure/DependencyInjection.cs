using ClashRoyaleClanWarsAPI.Application.Interfaces;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Infrastructure.Common;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Triggers;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Auth;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClashRoyaleClanWarsAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
             {
                 options.Password.RequireDigit = true;
                 options.Password.RequireLowercase = true;
                 options.Password.RequireUppercase = true;
                 options.Password.RequiredLength = 6;
             });

            AddPersistance(services);

            AddScopeds(services);

            services.AddTransient(typeof(Lazy<>), typeof(LazilyResolved<>)); //Important circular reference

            return services;
        }
        private static void AddScopeds(IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IBattleRepository, BattleRepository>();
            services.AddScoped<IClanRepository, ClanRepository>();
            services.AddScoped<IWarRepository, WarRepository>();
            services.AddScoped<IChallengeRepository, ChallengeRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();

            services.AddScoped<IPredefinedQueries, PredefinedQueries>();
        }

        private static void AddPersistance(IServiceCollection services)
        {
            services.AddDbContext<ClashRoyaleDbContext>(options =>
            {
                options.UseSqlServer(DbSettings.ConnectionName);
                options.UseTriggers(triggerOpt =>
                {
                    triggerOpt.AddTrigger<UpdateCardAmountTrigger>();
                    triggerOpt.AddTrigger<UpdateMaxEloInsertPlayerTrigger>();
                    triggerOpt.AddTrigger<UpdatePlayerStatsInsertBattleTrigger>();
                    triggerOpt.AddTrigger<UpdateAmountClanMembersTrigger>();
                });
            });
        }
    }
}
