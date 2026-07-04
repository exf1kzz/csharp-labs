using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountId, Account> _values = new();

    public void Add(Account account)
    {
        _values.Add(account.Id, account);
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        return _values.Values
            .Where(a => query.Ids is [] || query.Ids.Contains(a.Id));
    }
}