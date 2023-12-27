namespace Accounts;

public class AccountFactory
{
    public BasicAccount CreateAccount(AccountType Type, string UserName, string UserPassword)
    {
        switch (Type)
        {
            case AccountType.Standard:
                return new StandardAccount(UserName, UserPassword);
            case AccountType.Bonus:
                return new BonusAccount(UserName, UserPassword);
            default: throw new ArgumentException("Unsupported account type");
        }
    }
}