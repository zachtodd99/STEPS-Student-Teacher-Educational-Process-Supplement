using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserStruct{
    public string username;
    public string password;
    public List<QuizStatistic> quizRecord = new List<QuizStatistic>();
    public int totalPointsOverall;

    public UserStruct()
    {
        username = "";
        password = "";
    }

    public UserStruct(string inputUsername, string inputPassword)
    {
        username = inputUsername;
        password = inputPassword;
    }

    public void updateQuizRecord(int quizId, double quizPercentage, int score)
    {
        if (quizId == -1)
        {
            quizRecord.Add(new QuizStatistic(quizRecord.Count));
            quizId = quizRecord.Count;
        }
        else if (quizRecord.FindIndex(f => f.quizID == quizId) == -1)
        {
            quizRecord.Add(new QuizStatistic(quizId));
        }
        Debug.Log("Adding new score " + score + "to quiz " + quizId);
        quizRecord[quizRecord.FindIndex(f => f.quizID == quizId)].addNewScore(quizPercentage, score);
        totalPointsOverall += score;
    }



    public bool checkPasswordMatch(string inputPassword)
    {
        return inputPassword.Equals(password);
    }
}
