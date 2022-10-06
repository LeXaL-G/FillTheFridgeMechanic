using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void CloseBox()
    {
        ClickManager.instance.ActiveBox?.CloseBox();
    }
}
