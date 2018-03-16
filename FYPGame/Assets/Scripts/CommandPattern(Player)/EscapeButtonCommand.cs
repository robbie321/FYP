
public class EscapeButtonCommand : ICommand
{
    UIManager controls;
    public  EscapeButtonCommand(UIManager controls)
    {
        this.controls = controls;
    }
    public void Execute()
    {
        controls.OpenCloseMenu();
    }

    public void Undo()
    {
        
    }
}
