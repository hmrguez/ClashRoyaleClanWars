﻿namespace ClashRoyaleClanWarsAPI.Application.Responses;

public record FirstQueryResponse(int PlayerId, string PlayerName, int Trophies, int ClanId, string ClanName);
