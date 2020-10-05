namespace TestDrivenDesign
{
    public interface IAccountRepository
    {
        Account GetByName(string accountName);
    }
}