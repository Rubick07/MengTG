using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUI : MonoBehaviour
{
    public GameObject UpgradeUI;
    //public GameObject TextObject;
    private bool nyala = false;

    private void OnMouseDown()
    {
        Debug.Log("Masuk");
        nyala = !nyala;

        UpgradeUI.SetActive(nyala);
    }


}
