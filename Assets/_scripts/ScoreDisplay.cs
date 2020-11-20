using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<QuestionRunner>().DisplayResults();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
