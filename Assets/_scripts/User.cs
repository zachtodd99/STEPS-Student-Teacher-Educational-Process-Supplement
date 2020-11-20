using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class User : MonoBehaviour {

    public bool isLoggedIn;
    public string myUsername;
    public int totalPointsOverall = 0;
    public List<QuizStatistic> quizRecord = new List<QuizStatistic>();
    public GameObject incorrectLoginPrefab;

    public UserStruct myUser = new UserStruct();


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}


    public void attemptLogin()
    {
        string username = GameObject.Find("UsernameField").GetComponent<InputField>().text;
        string password = GameObject.Find("PasswordField").GetComponent<InputField>().text;

        string jsonString = PlayerPrefs.GetString("User " + username);


        if (jsonString.Equals(""))
        {
            Debug.Log("Creating new user: " + username);
            UserStruct foundUser = new UserStruct(username, password);
            myUsername = username;
            isLoggedIn = true;
            totalPointsOverall = foundUser.totalPointsOverall;
            quizRecord = foundUser.quizRecord;
            myUser = foundUser;

            saveUserData();

            GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadNewScene("MyProfile");
        }
        else {

            UserStruct foundUser = JsonUtility.FromJson<UserStruct>(PlayerPrefs.GetString("User " + username));

            if (foundUser.checkPasswordMatch(password))
            {
                myUsername = username;
                isLoggedIn = true;
                totalPointsOverall = foundUser.totalPointsOverall;
                quizRecord = foundUser.quizRecord;
                myUser = foundUser;
                GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadNewScene("MyProfile");
            }
            else
            {
                Debug.Log("Password for " + username + " did not match!");
                Instantiate(incorrectLoginPrefab, GameObject.Find("Canvas").transform);
            }
        }

    }

    public void logout()
    {
        isLoggedIn = false;
        myUsername = "";
        Destroy(gameObject);
    }

    public void updateQuizRecord(int quizId, double quizPercentage, int score)
    {
        myUser.updateQuizRecord(quizId, quizPercentage, score);
        totalPointsOverall = myUser.totalPointsOverall;
    }

    public int getTotalPointsOverall()
    {
        return totalPointsOverall;
    }

    public void saveUserData()
    {
        PlayerPrefs.SetString("User " + myUser.username, JsonUtility.ToJson(myUser));
        
    }



}
