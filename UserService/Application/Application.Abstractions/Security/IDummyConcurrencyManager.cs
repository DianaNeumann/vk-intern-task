namespace Application.Abstractions.Security;

public interface IDummyConcurrencyManager
{
    /* I got bored and decided to have fun with naming */ 
    
    void RegistrationKnocking(string login);
    bool IsRacingSituationNow(string login);

    void RemoveValue(string login);

}