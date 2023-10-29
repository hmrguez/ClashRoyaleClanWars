using ClashRoyaleClanWarsAPI.Domain.Common;

namespace ClashRoyaleClanWarsAPI.Domain.Models.Battle.ValueObjects;

public sealed class BattleId : ValueObject
{
    public Guid Value { get; set; }

    private BattleId(Guid value)
    {
        Value = value;
    }
    private BattleId() { }

    public static BattleId CreateUnique() => new(Guid.NewGuid());
    public static BattleId Create(Guid value) => new(value);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
    }
}
