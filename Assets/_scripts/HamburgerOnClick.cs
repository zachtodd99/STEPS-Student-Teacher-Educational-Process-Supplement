using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HamburgerOnClick : MonoBehaviour {

    private bool menuOut = false;

    private void Start()
    {

        
        transform.Translate(new Vector3(-Screen.width, 0, 0));
    }


    public void HamburgerBarPressed()
    {
        if (menuOut)
        {
            transform.Translate(new Vector3(-Screen.width, 0, 0));
        }
        else
        {
            transform.Translate(new Vector3(Screen.width, 0, 0));

        }

        Debug.Log("Hamburger Bar Pressed");
        menuOut = !menuOut;
    }

}
