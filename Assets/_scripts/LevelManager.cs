using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadNewScene(string name)
    {
        // Press the space key to start coroutine
        
        // Use a coroutine to load the Scene in the background
        if (name.Contains("Quiz "))
        {
            if (FindObjectOfType<Application>().GetComponent<Application>().requestNewCurrentQuiz(Int32.Parse(name.Substring(5))) == -1){
                Debug.Log("Couldn't load quiz " + name.Substring(5));
                FindObjectOfType<Application>().GetComponent<Application>().requestNewCurrentQuiz(0);

            }
            else
            {
                StartCoroutine(LoadYourAsyncScene("Quiz"));
            }
        }
        else
        {
            StartCoroutine(LoadYourAsyncScene(name));
        }
       
        
    }

    IEnumerator LoadYourAsyncScene(string name)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        if (name.Equals("LoginMenu"))
        {
            GameObject.Find("User").GetComponent<User>().logout();
        }

        if (!name.Equals("QuizResult"))
        {
            QuestionRunner qr = FindObjectOfType<QuestionRunner>();
            if (qr!=null)
            {
                GameObject.Destroy(qr.gameObject);
            }
        }

        Debug.Log("loading scene " + name);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
