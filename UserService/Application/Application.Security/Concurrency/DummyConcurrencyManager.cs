using Application.Abstractions.Security;

namespace Application.Security.Concurrency;

public class DummyConcurrencyManager : IDummyConcurrencyManager
{
    private readonly HashSet<string> _attemptsToRegister;

    public void RegistrationKnocking(string login) => _attemptsToRegister.Add(login);
    
    public bool IsRacingSituationNow(string login) => _attemptsToRegister.Contains(login);
    
    public void RemoveValue(string login) => _attemptsToRegister.Remove(login);
}