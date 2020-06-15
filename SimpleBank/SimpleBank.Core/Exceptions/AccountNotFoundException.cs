namespace SimpleBank.Core.Exceptions
{
    public class AccountNotFoundException : DomainException
    {
        public AccountNotFoundException(in int accountId) : base($"Account with id: {accountId} not found")
        {
        }
    }
}