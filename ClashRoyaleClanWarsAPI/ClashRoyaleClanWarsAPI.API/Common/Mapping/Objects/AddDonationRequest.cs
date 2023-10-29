namespace ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;

public class AddDonationRequest
{
    public int ClanId { get; set; }
    public int CardId { get; set; }
    public int Amount { get; set; }
}
