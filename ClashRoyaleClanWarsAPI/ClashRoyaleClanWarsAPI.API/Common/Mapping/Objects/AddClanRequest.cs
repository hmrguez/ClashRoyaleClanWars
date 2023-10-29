namespace ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;

public class AddClanRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Region { get; set; }
    public bool TypeOpen { get; set; }
    public int MinTrophies { get; set; }
}
