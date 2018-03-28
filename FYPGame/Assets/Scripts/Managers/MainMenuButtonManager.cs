using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonManager : Singleton<MainMenuButtonManager> {

    public void NewGameButton(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }


    public void OnButtonClicked()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
    }
}
