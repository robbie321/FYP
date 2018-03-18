
public class EscapeButtonCommand : ICommand
{
    public EscapeButtonCommand(/*UIManager controls*/)
    {
        //this.controls = controls;
    }
    public void Execute()
    {
        UIManager.Instance.OpenCloseMenu();
    }

    public void Execute(string name)
    {
        throw new System.NotImplementedException();
    }

    public void Undo()
    {
        
    }
}
