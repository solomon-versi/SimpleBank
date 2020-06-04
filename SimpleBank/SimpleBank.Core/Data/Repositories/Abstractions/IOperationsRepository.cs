using System.Collections.Generic;
using SimpleBank.Core.Models;

namespace SimpleBank.Core.Data.Repositories.Abstractions
{
    public interface IOperationsRepository
    {
        Operation GetOperationById(long id);

        List<Operation> GetOperationsByAccountId(int accountId);

        int SaveOperation(Operation operation);
    }
}