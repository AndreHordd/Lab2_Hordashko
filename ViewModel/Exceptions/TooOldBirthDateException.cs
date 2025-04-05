namespace Laboratory2.ViewModel.Exceptions;

public class TooOldBirthDateException : Exception
{
    public TooOldBirthDateException()
        : base("Дата народження занадто стара (вік більше 135 років). Ми маємо справу лише з живими людьми.") { }

    public TooOldBirthDateException(string message)
        : base(message) { }

    public TooOldBirthDateException(string message, Exception inner)
        : base(message, inner) { }
}