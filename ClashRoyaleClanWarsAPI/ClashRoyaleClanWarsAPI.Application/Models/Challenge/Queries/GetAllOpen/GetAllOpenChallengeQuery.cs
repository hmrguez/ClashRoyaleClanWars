using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Challenge.Queries.GetAllOpen;

public record GetAllOpenChallengeQuery() : IQuery<IEnumerable<ChallengeModel>>;
