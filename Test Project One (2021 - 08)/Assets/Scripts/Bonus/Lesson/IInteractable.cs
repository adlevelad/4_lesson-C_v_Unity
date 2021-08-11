namespace TestProjectOne
{
    public interface IInteractable : IAction, IInitialization
    {
        bool IsInteractable { get; }
    //void Interactable();
    }
}
