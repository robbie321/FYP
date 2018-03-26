using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour
{
    public GameObject gameManager;          //GameManager prefab to instantiate.
    public GameObject soundManager;         //SoundManager prefab to instantiate.
    public GameObject UiManager;
    public GameObject InputManager;
    public GameObject headsUpDisplay;


    void Awake()
    {
        ////Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.instance == null)

           // Instantiate gameManager prefab
            Instantiate(gameManager);

        //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
        if (AudioManager.instance == null)

            //Instantiate SoundManager prefab
            Instantiate(soundManager);
        //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
        if (UIManager.Instance == null)

            //Instantiate SoundManager prefab
            Instantiate(UiManager);
        //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
        if (KeyboardInput.Instance == null)

            //Instantiate SoundManager prefab
            Instantiate(InputManager);
        ////Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
        //if (HUD.instance == null)

        //    //Instantiate SoundManager prefab
        //    Instantiate(headsUpDisplay);
    }
}