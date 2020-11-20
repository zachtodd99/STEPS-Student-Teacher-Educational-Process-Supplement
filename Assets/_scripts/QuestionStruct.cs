
using System;
using System.Collections.Generic;


[Serializable]
public class QuestionStruct {
    public string text;
    public List<AnswerStruct> answers = new List<AnswerStruct>();
    public int time = 10;

    public QuestionStruct()
    {
        text = "";
    }

    public QuestionStruct(string inputText)
    {
        text = inputText;
    }

    public QuestionStruct(string inputText, int inputTime)
    {
        text = inputText;
        time = inputTime;
    }

    public void addAnswer(string text, bool isCorrect)
    {
        answers.Add(new AnswerStruct(text, isCorrect));
    }

    public void addAnswer(AnswerStruct a)
    {
        answers.Add(a);
    }

    public void removeAllAnswers()
    {
        answers = new List<AnswerStruct>();
    }
}
