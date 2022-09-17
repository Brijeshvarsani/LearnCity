using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closePanels : MonoBehaviour
{
    public GameObject closePanelBox;

    public void closePanel()
    {
        if (closePanelBox != null)
        {
            closePanelBox.SetActive(false);
        }
    }
}
