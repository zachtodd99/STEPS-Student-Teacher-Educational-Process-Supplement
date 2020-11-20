using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePageWelcome : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("username:" + GameObject.Find("User").GetComponent<User>().myUsername);
        gameObject.GetComponent<Text>().text = "Hello " + GameObject.Find("User").GetComponent<User>().myUsername + "!";
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
