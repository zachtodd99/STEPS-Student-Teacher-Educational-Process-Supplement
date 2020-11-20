using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour {

    private GameObject runner;

    public int index;

	// Use this for initialization
	void Start () {
        runner = GameObject.Find("Question Runner");
	}
	

    public void chooseThisAnswer()
    {
        runner.GetComponent<QuestionRunner>().chooseAnswer(index);
    }
}
