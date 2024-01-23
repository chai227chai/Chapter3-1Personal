using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupManager : MonoBehaviour
{
    public void PopUi(GameObject ui)
    {
        ui.SetActive(true);
    }

    public void CloseUi(GameObject ui)
    {
        ui.SetActive(false);
    }
}
