using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizSelector : MonoBehaviour {

    public GameObject quizMenuItemPrefab;
    public Sprite[] ratingImages = new Sprite[4];
    public List<string> quizNames;
    public List<int> questionCounts;
    public List<int> rating;
    public List<int> quizIndexs;


	// Use this for initialization
	void Start () {
        quizNames = new List<string>();
        questionCounts = new List<int>();
        rating = new List<int>();
        quizIndexs = new List<int>();
        Debug.Log("Quiz count: " + PlayerPrefs.GetInt("QuizCount"));
        for(int x = 0; x<PlayerPrefs.GetInt("QuizCount"); x++)
        {
            string jsonText = PlayerPrefs.GetString("Quiz " + x);
            if (!jsonText.Equals(""))
            {
                QuizStruct myStruct = JsonUtility.FromJson<QuizStruct>(jsonText);

                GameObject menuItem = Instantiate(quizMenuItemPrefab, transform) as GameObject;

                menuItem.transform.Find("Quiz Name").GetComponent<Text>().text = myStruct.name;
                menuItem.transform.Find("Quiz Question Count").GetComponent<Text>().text = myStruct.questions.Count + "Q";
                menuItem.transform.Find("Quiz Rating").GetComponent<Image>().sprite = ratingImages[(int) Math.Floor(myStruct.rating)];



                //menuItem.GetComponent<Button>().onClick.AddListener(() => FindObjectOfType<Application>().GetComponent<Application>().requestNewCurrentQuiz(quizIndexs[x]));

                //FindObjectOfType<LevelManager>().GetComponent<LevelManager>().LoadNewScene("Quiz");


                menuItem.GetComponent<Button>().onClick.AddListener(() => FindObjectOfType<LevelManager>().GetComponent<LevelManager>().LoadNewScene("Quiz " + myStruct.quizID));
            }
            
        }

        

        /*dummyData();

		for(int x = 0; x<quizNames.Count; x++)
        {

        }*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void dummyData()
    {
        quizNames.Add("Basic History");
        questionCounts.Add(25);
        rating.Add((int) Mathf.Floor(UnityEngine.Random.Range(0,4)));
        quizIndexs.Add(0);

        quizNames.Add("testing 1");
        questionCounts.Add(5);
        rating.Add((int)Mathf.Floor(UnityEngine.Random.Range(0, 4)));
        quizIndexs.Add(0);

        quizNames.Add("Basic Math");
        questionCounts.Add(12);
        rating.Add((int)Mathf.Floor(UnityEngine.Random.Range(0, 4)));
        quizIndexs.Add(0);

        quizNames.Add("Advanced Economics");
        questionCounts.Add(17);
        rating.Add((int)Mathf.Floor(UnityEngine.Random.Range(0, 4)));
        quizIndexs.Add(0);

        quizNames.Add("Mrs. Jules' Geometry");
        questionCounts.Add(20);
        rating.Add((int)Mathf.Floor(UnityEngine.Random.Range(0, 4)));
        quizIndexs.Add(0);
    }





}
