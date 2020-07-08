namespace SimpleBank.Core.Exceptions
{
    public class InsufficientFundsException : DomainException
    {
        public InsufficientFundsException(in int accountId) : base($"Insufficient funds on account: {accountId}")
        {
        }
    }
}