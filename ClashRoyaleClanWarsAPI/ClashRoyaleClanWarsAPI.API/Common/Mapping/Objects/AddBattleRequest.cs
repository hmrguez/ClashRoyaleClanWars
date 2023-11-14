namespace ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;

public class AddBattleRequest
{
    public int AmountTrophies { get; set; }
    public int WinnerId { get; set; }
    public int LoserId { get; set; }
    public int DurationInSeconds { get; set; }
    public DateTime Date {  get; set; }
}
