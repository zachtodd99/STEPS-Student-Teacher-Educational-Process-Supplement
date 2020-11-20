using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {

    public List<GameObject> questions;
    //public List<Question> questionsInfo;
    public GameObject questionPrefab;
    private int quizIndex = -1;
    public string quizName;
    private GameObject contentObject;

    public QuizStruct myStruct;

	// Use this for initialization
	void Start () {

        Debug.Log("Creating new quiz");

        contentObject = GameObject.Find("Content");
        
        questions = new List<GameObject>();

        quizIndex = PlayerPrefs.GetInt("QuizCount");
        //questionsInfo = new List<Question>();
        
	}


    public void addQuestion(string text)
    {
        
        GameObject q = Instantiate(questionPrefab, transform) as GameObject;
        //questionsInfo.Add(q.GetComponent<Question>());
        questions.Add(q);
        q.GetComponent<Question>().setIndex(questions.Count-1);
        q.GetComponent<Question>().setText(text);
        q.transform.SetSiblingIndex(transform.childCount-2);
    }

    public void removeQuestion(int index)
    {
        Debug.Log("removing question " + index);
        int indexInScoller = questions[index].transform.GetSiblingIndex();
        Question myQ = questions[index].GetComponent<Question>();

        if (myQ.expanded) { 
            int answers = myQ.answers.Count;
            for(int x = 0; x < answers+2; x++)
            {
                GameObject.Destroy(transform.GetChild(x + indexInScoller).gameObject);
            }
        }
        GameObject.Destroy(questions[index]);
        questions.RemoveAt(index);
        int counter = 0;
        foreach(GameObject go in questions)
        {
            go.GetComponent<Question>().setIndex(counter);
            counter++;
        }

    }

    public void saveQuiz()
    {


        Debug.Log("Saving quiz");
        quizName = GameObject.Find("DeckName").GetComponent<InputField>().text;
        contentObject.name = quizName;

        myStruct = new QuizStruct(quizIndex, quizName);

        foreach (GameObject q in questions)
        {
            if (q.GetComponent<Question>().expanded)
            {
                q.GetComponent<Question>().expandCollapse();
                q.GetComponent<Question>().expandCollapse();
            }
            q.GetComponent<Question>().saveQuestion();
            myStruct.addQuestion(q.GetComponent<Question>().myStruct);
        }


        myStruct.quizID = FindObjectOfType<Application>().GetComponent<Application>().modifyQuiz(myStruct);
        
    }

    public void saveAndExit()
    {
        saveQuiz();
        FindObjectOfType<LevelManager>().GetComponent<LevelManager>().LoadNewScene("Quizzes");
    }
}
