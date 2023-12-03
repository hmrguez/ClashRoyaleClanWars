using ClashRoyaleClanWarsAPI.Domain.Enum;

namespace ClashRoyaleClanWarsAPI.Application.Responses;

public record FourthQueryResponse(int ClanId,
                                  string ClanName,
                                  int CardId,
                                  string CardName,
                                  TypeCardEnum CardType,
                                  int Count);
