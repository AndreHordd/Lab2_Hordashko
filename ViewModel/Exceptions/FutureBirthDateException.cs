namespace Laboratory2.ViewModel.Exceptions;

public class FutureBirthDateException : Exception
{
    public FutureBirthDateException()
        : base("Дата народження не може бути в майбутньому.") { }

    public FutureBirthDateException(string message)
        : base(message) { }

    public FutureBirthDateException(string message, Exception inner)
        : base(message, inner) { }
}