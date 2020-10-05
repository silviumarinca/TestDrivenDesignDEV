namespace BetterDesign
{
    public interface IAccountRepository
    {
        Account GetByName(string accountName);
        Account NewAccount(AccountBase accountbase);
    }
}