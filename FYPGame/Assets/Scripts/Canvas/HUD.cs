using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{



    public GameObject MessagePanel;

    // Use this for initialization
    void Start()
    {

    }

   

    private bool mIsMessagePanelOpened = false;

    public bool IsMessagePanelOpened
    {
        get { return mIsMessagePanelOpened; }
    }

    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);

        mIsMessagePanelOpened = true;

        // TODO: set text when we will use this for other messages as well
    }

    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);

        mIsMessagePanelOpened = false;
    }
}
