using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour {

    
    public List<string> answers;
    public List<bool> questionCorrectFlag;
    public string text;
    private int qIndex;


    public bool expanded;
    public Sprite rightArrow;
    public Sprite downArrow;
    public GameObject answerPrefab;
    public GameObject addAnswerPrefab;

    public QuestionStruct myStruct;


    public void setText(string inputText)
    {
        text = inputText;

        if (inputText != "")
        {
            transform.Find("QuestionText").transform.Find("Text").GetComponent<Text>().text = inputText;
        }

    }

    public Question(string inputText)
    {
        text = inputText;
    }

    public void setIndex(int index)
    {
        qIndex = index;
        transform.Find("QuestionTitle").GetComponent<Text>().text = "Question " + (qIndex+1) + ":";
        Quiz q = FindObjectOfType<Quiz>().GetComponent<Quiz>();
        transform.Find("RemoveButton").GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        transform.Find("RemoveButton").GetComponentInChildren<Button>().onClick.AddListener(() => q.removeQuestion(qIndex));
    }

    // Use this for initialization
    void Start() {
        expanded = false;
        answers = new List<string>();
        questionCorrectFlag = new List<bool>();
        
        
    }

    public void expandCollapse()
    {
        if (expanded)
        {
            transform.Find("ExpandButton").GetComponent<Image>().sprite = rightArrow;
            for (int x = 0; x < answers.Count + 1; x++)
            {
                Transform ans = transform.parent.transform.GetChild(transform.GetSiblingIndex() + x + 1);
                if (x < answers.Count)
                {
                    updateAnswer(x, ans.Find("AnswerField").GetComponent<InputField>().text, ans.Find("isCorrect").GetComponent<Toggle>().isOn);
                }
                GameObject.Destroy(ans.gameObject);
            }

            
        }
        else
        {
            transform.Find("ExpandButton").GetComponent<Image>().sprite = downArrow;
            int count = 1;
            foreach (string s in answers)
            {
                GameObject ans = Instantiate(answerPrefab, transform.parent) as GameObject;
                ans.transform.Find("AnswerLabel").GetComponent<Text>().text = "Answer " + count + ":";
                if (s != "")
                {
                    ans.transform.Find("AnswerField").GetComponent<InputField>().text = s;
                }
                ans.transform.SetSiblingIndex(transform.GetSiblingIndex() + count);
                ans.transform.Find("isCorrect").GetComponent<Toggle>().isOn = questionCorrectFlag[count-1];
                int num = count - 1;
                ans.GetComponentInChildren<Button>().onClick.AddListener(
                    ()=> removeAnswer(num) );
                count++;
            }
            GameObject but = Instantiate(addAnswerPrefab, transform.parent) as GameObject;
            but.transform.SetSiblingIndex(transform.GetSiblingIndex() + count);
            but.GetComponentInChildren<Button>().onClick.AddListener(addAnswer);
        }
        expanded = !expanded;
    }

    public void removeAnswer(int index)
    {
        expandCollapse();
        Debug.Log("removing question " + index);
        answers.RemoveAt(index);
        questionCorrectFlag.RemoveAt(index);
        
        expandCollapse();
    }

    public void addAnswer()
    {
        int mySibIndex = transform.GetSiblingIndex();
        GameObject ans = Instantiate(answerPrefab, transform.parent) as GameObject;
        ans.transform.Find("AnswerLabel").GetComponent<Text>().text = "Answer " + (answers.Count + 1) + ":";
        ans.transform.SetSiblingIndex(mySibIndex + answers.Count + 1);
        int num = answers.Count;
        ans.GetComponentInChildren<Button>().onClick.AddListener(() => removeAnswer(num) );
        answers.Add("");
        questionCorrectFlag.Add(false);
    }

    public void updateAnswer(int index, string text, bool isCorrect)
    {
        answers[index] = text;
        questionCorrectFlag[index] = isCorrect;
    }

    public void saveQuestion()
    {
        myStruct = new QuestionStruct(transform.Find("QuestionText").GetComponent<InputField>().text);
        int counter = 0;
        foreach (string s in answers)
        {
            myStruct.addAnswer(new AnswerStruct(s, questionCorrectFlag[counter]));
            counter++;
        }
        
    }


}
