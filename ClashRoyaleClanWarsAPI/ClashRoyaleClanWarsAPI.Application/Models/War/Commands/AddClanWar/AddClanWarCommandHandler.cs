using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.War.Commands.AddClanWar
{
    internal class AddClanWarCommandHandler : ICommandHandler<AddClanWarCommand>
    {
        private readonly IWarRepository _warRepository;

        public AddClanWarCommandHandler(IWarRepository warRepository)
        {
            _warRepository = warRepository;
        }

        public async Task<Result> Handle(AddClanWarCommand request, CancellationToken cancellationToken)
        {
            await _warRepository.AddClanToWar(request.WarId, request.ClanId, request.Prize);

            return Result.Success();
        }
    }
}
