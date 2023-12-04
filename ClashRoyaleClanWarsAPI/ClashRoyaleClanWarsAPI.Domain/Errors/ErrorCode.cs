namespace ClashRoyaleClanWarsAPI.Domain.Errors;

public class ErrorCode
{
    public const string DuplicateId = "Model.DuplicateId";
    public const string ModelNotFound = "Model.ModelNotFound";
    public const string IdNotFound = "Model.IdNotFound";
    public const string IdsNotMatch = "Model.IdsNotMatch";
    public const string ChallengeClosed = "Challenge.ChallengeClosed";
    public const string PlayerNotHaveCard = "Player.PlayerNotHaveCard";
    public const string NullValue = "Error.NullValue";
    public const string Validation = "Error.Validation";
    public const string UsernameNotFound = "Auth.UsernameNotFound";
    public const string DuplicateUsername = "Auth.DuplicateUsername";
    public const string InvalidCredentials = "Auth.InvalidCredentials";
    public const string InvalidPassword = "Auth.InvalidPassword";
    public const string PasswordsNotMatch = "Auth.PasswordsNotMatch";
    public const string PlayerHasClan = "Player.PlayerHasClan";
    public const string PlayerHasNoClan = "Player.PlayerHasNoClan";
    public const string PlayerHasNoEnoughTrophies = "Player.PlayerHasNoEnoughTrophies";
    public const string RoleNotFound = "Auth.RoleNotFound";
    public const string ClanAlreadyInWar = "Clan.ClanAlreadyInWar";
    public const string ClanFull = "Clan.ClanFull";
    public const string WarFull = "War.WarFull";
    public const string PlayerHasNoEnoughLevel = "Player.PlayerHasNoEnoughLevel";


}
