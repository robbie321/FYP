using System;
using UnityEngine;
//class must be serializable so we can see it in the editor
[Serializable]
public class SightBlock
{
    [SerializeField]
    private GameObject firstBlock, secondBlock;
    //deactivate sight blocks
    public void DeactivateBlock()
    {
        firstBlock.SetActive(false);
        secondBlock.SetActive(false);
    }
    //activate sight blocks
    public void ActivateBlock()
    {
        firstBlock.SetActive(true);
        secondBlock.SetActive(true);
    }
}

