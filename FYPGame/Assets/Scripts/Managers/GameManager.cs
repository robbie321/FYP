using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private MoveUpCommand up;
    private MoveLeftCommand left;
    private MoveDownCommand down;
    private MoveRightCommand right;
    private EscapeButtonCommand escape;
    private ActionButtonOne actionButtonOne;
    private ActionButtonTwo actionButtonTwo;
    private ActionButtonThree actionButtonThree;
    private ActionButtonFour actionButtonFour;
    private ActionButtonFive actionButtonFive;
    private EButtonCommand openCloseBook;
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
        SetActivePlayer();
        SetControllerCommand();
    }

    // Update is called once per frame
    void Update()
    {
        //Executes click target
        ClickTarget();
        KeyboardInput.Instance.HandleInput();
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

                Player.Instance.Target = currentTarget.Select(); //Gives the player the new target


            }
            else//Deselect the target
            {


                if (currentTarget != null) //If we have a current target
                {
                    currentTarget.DeSelect(); //We deselct it
                }

                //We remove the references to the target
                currentTarget = null;
                Player.Instance.Target = null;
            }
        }

    }


    public void SetActivePlayer()
    {
        up = new MoveUpCommand();
        left = new MoveLeftCommand();
        down = new MoveDownCommand();
        right = new MoveRightCommand();
        escape = new EscapeButtonCommand();
        actionButtonOne = new ActionButtonOne();
        actionButtonTwo = new ActionButtonTwo();
        actionButtonThree = new ActionButtonThree();
        actionButtonFour =  new ActionButtonFour();
        actionButtonFive = new ActionButtonFive();
        openCloseBook = new EButtonCommand();
    }


    //INVOKER
    public void SetControllerCommand()
    {
        KeyboardInput.Instance.SetCommand("W", up);
        KeyboardInput.Instance.SetCommand("A", left);
        KeyboardInput.Instance.SetCommand("S", down);
        KeyboardInput.Instance.SetCommand("D", right);
        KeyboardInput.Instance.SetCommand("E", openCloseBook);
        KeyboardInput.Instance.SetCommand("Escape", escape);
        KeyboardInput.Instance.SetCommand("ACT1", actionButtonOne);
        KeyboardInput.Instance.SetCommand("ACT2", actionButtonTwo);
        KeyboardInput.Instance.SetCommand("ACT3", actionButtonThree);
        KeyboardInput.Instance.SetCommand("ACT4", actionButtonFour);
        KeyboardInput.Instance.SetCommand("ACT5", actionButtonFive);


    }

}
