using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;

public class AddPlayerRequest
{
    public string? Alias { get; set; }
    public int Elo { get; set; }
    public int Level { get; set; }
}
