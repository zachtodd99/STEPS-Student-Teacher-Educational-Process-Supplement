using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour {

    public GameObject statPrefab;

	// Use this for initialization
	void Start () {
        User user = GameObject.Find("User").GetComponent<User>();

        user.saveUserData();

        GameObject.Find("Total Score").GetComponent<Text>().text = "Total Points: " + user.getTotalPointsOverall();

        if(user.quizRecord.Count == 0)
        {
            gameObject.active = false;
        }
        // TODO: change this to add a new gameobject for each stat
        for(int x = 0; x<user.quizRecord.Count;x++)
        {
            GameObject newStat = Instantiate(statPrefab,transform.parent);

            newStat.GetComponent<Text>().text =
            "Quiz: " + user.quizRecord[x].quizName +
            "\nTimes Taken: " + user.quizRecord[x].timesTaken +
            "\nAverage Percentage Correct: " + Math.Floor(10000 * user.quizRecord[x].averagePercentageCorrect)/100 + "%" + 
            "\nHigh Score: " + user.quizRecord[x].highScore + "\n\n";
            newStat.transform.SetSiblingIndex(transform.GetSiblingIndex() + x + 1);
        }



    }

}
