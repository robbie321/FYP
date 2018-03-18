
public class EscapeButtonCommand : ICommand
{

    public void Execute()
    {
        UIManager.Instance.OpenClose(UIManager.Instance.Controls);
    }

    public void Execute(string name)
    {

    }

    public void Undo()
    {
        
    }
}
