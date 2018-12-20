namespace SmartHomeSystem.Domain.DomainBase
{
    public interface ICommandWithResult<T> : ICommand
    {
        T Result { get; }
    }
}
