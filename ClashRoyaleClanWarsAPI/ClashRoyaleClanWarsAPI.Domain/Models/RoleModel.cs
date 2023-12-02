using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;

namespace ClashRoyaleClanWarsAPI.Domain.Models;

public class RoleModel : IEntity<Guid>
{
    private RoleModel() { }
    private RoleModel(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public List<UserModel> Users { get; private set; }

    public static RoleModel Create(string name) => new RoleModel(name);

}
