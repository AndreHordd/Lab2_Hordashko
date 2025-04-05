namespace Laboratory2.ViewModel.Exceptions;

public class InvalidEmailException : Exception
{
    public InvalidEmailException()
        : base("Невірна адреса електронної пошти.") { }

    public InvalidEmailException(string message)
        : base(message) { }

    public InvalidEmailException(string message, Exception inner)
        : base(message, inner) { }
}