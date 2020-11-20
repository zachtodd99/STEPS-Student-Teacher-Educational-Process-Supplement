using System;
using System.Collections.Generic;

[Serializable]
public class QuizStruct{
    public string name;
    public int quizID;
    public List<QuestionStruct> questions = new List<QuestionStruct>();
    public double rating = 0.0;
    public int numberOfRatings = 0;

    public QuizStruct()
    {
        name = "";
        quizID = -1;
    }

    public QuizStruct(int inputID)
    {
        quizID = inputID;
    }

    public QuizStruct(int inputID, string inputName)
    {
        quizID = inputID;
        name = inputName;
    }

    public void addQuestion(QuestionStruct q)
    {
        questions.Add(q);
    }

    public void removeAllQuestions()
    {
        questions = new List<QuestionStruct>();
    }

    public void updateName(string s)
    {
        name = s;
    }

    public void updateQuizID(int id)
    {
        quizID = id;
    }

    public void rateQuiz(int newRating)
    {
        rating = (rating * numberOfRatings + newRating) / numberOfRatings;
        numberOfRatings++;
    }

}
