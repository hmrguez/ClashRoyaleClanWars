using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;

namespace ClashRoyaleClanWarsAPI.Domain.Models;

public class UserModel : IEntity<Guid>
{
    private UserModel() { }
    private UserModel(string username, Guid roleId)
    {
        Id = Guid.NewGuid();
        UserName = username;
        RoleId = roleId;
    }
    private UserModel(string username)
    {
        Id = Guid.NewGuid();
        UserName = username;
    }
    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public string PasswordHash { get; set; }
    public Guid? RoleId { get; set; }
    public RoleModel? Role { get; set; }
    public int? PlayerId { get; set; }
    public PlayerModel? Player { get; set; }

    public static UserModel Create(string username, Guid roleId) => new UserModel(username, roleId);
}
