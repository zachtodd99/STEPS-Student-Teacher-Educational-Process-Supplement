using System;
using UnityEngine;

[Serializable]
public class QuizStatistic
{
    public int quizID;
    public double averagePercentageCorrect;
    public double totalScores;
    public double highScore;
    public int timesTaken;
    public string quizName;

    public QuizStatistic()
    {
        quizID = -1;
        averagePercentageCorrect = 0.0;
        totalScores = 0;
        highScore = 0;
        timesTaken = 0;
    }

    public QuizStatistic(int quizIdInput)
    {
        quizID = quizIdInput;
        averagePercentageCorrect = 0.0;
        totalScores = 0;
        highScore = 0;
        timesTaken = 0;
    }

    public void addNewScore(double percentageCorrect, double score)
    {
        averagePercentageCorrect = (percentageCorrect + (averagePercentageCorrect * timesTaken)) / (timesTaken + 1);
        totalScores += score;
        if (highScore < score)
        {
            highScore = score;
        }
        timesTaken++;
        quizName = JsonUtility.FromJson<QuizStruct>(PlayerPrefs.GetString("Quiz " + quizID)).name;
    }

}
