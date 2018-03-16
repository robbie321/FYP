using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //public float playerHealth;
    // public float playerMana;
    /// <summary>
    /// A reference to the player object
    /// </summary>
    [SerializeField]
    private Player player;
    [SerializeField]
    private UIManager commands;
    private KeyboardInput controller = new KeyboardInput();
    private MoveUpCommand up;
    private MoveLeftCommand left;
    private MoveDownCommand down;
    private MoveRightCommand right;
    private EscapeButtonCommand escape;
    private NPC currentTarget;
    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        SetUICommands(commands);
        SetActivePlayer(player);
        SetControllerCommand();
    }




    // Update is called once per frame
    void Update()
    {
        //Executes click target
        ClickTarget();
        controller.HandleInput();
    }

    private void ClickTarget()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())//If we click the left mouse button
        {
            //Makes a raycast from the mouse position into the game world
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 1024);

            if (hit.collider != null)//If we hit something
            {
                if (currentTarget != null)//If we have a current target
                {
                    currentTarget.DeSelect(); //deselct the current target
                }

                currentTarget = hit.collider.GetComponent<NPC>(); //Selects the new target

                player.Target = currentTarget.Select(); //Gives the player the new target


            }
            else//Deselect the target
            {


                if (currentTarget != null) //If we have a current target
                {
                    currentTarget.DeSelect(); //We deselct it
                }

                //We remove the references to the target
                currentTarget = null;
                player.Target = null;
            }
        }

    }
    //INVOKER
    public KeyboardInput GetKeyboardInput()
    {
        return controller;
    }

    public void SetActivePlayer(Character character)
    {
        up = new MoveUpCommand(character);
        left = new MoveLeftCommand(character);
        down = new MoveDownCommand(character);
        right = new MoveRightCommand(character);
    }

    public void SetUICommands(UIManager command)
    {
        escape = new EscapeButtonCommand(command);
    }

    public void SetControllerCommand()
    {
        controller.SetCommand("W", up);
        controller.SetCommand("A", left);
        controller.SetCommand("S", down);
        controller.SetCommand("D", right);
        controller.SetCommand("Escape", escape);
    }

}
