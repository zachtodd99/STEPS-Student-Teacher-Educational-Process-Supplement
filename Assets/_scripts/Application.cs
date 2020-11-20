using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application : MonoBehaviour {

    
    public List<User> users;
    //List<Classroom> classes;
    public int currentQuiz = 0;


    // Use this for initialization
    void Start()
    {
        
        if (PlayerPrefs.GetInt("QuizCount") == 0 || !JsonUtility.FromJson<QuizStruct>(PlayerPrefs.GetString("Quiz 0")).name.Equals("Basic History Quiz"))
        {
            makeSampleQuiz();
            
        }
        users = new List<User>();

        //classes = new List<Classroom>();
        if (FindObjectsOfType<Application>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    //returns the index of the new quiz
    public int addNewQuiz()
    {
        Debug.Log("added new quiz");
        QuizStruct newQuiz = new QuizStruct(PlayerPrefs.GetInt("QuizCount"));
        PlayerPrefs.SetString("Quiz " + newQuiz.quizID, JsonUtility.ToJson(newQuiz));
        PlayerPrefs.SetInt("QuizCount", PlayerPrefs.GetInt("QuizCount") + 1);
        return newQuiz.quizID;
    }

    public int modifyQuiz(QuizStruct q)
    {
        if(q.quizID>= PlayerPrefs.GetInt("QuizCount"))
        {
            q.quizID = PlayerPrefs.GetInt("QuizCount");
            PlayerPrefs.SetInt("QuizCount", PlayerPrefs.GetInt("QuizCount") + 1);
        }

        PlayerPrefs.SetString("Quiz " + q.quizID, JsonUtility.ToJson(q));
        Debug.Log("Modified quiz " + q.quizID);
        return q.quizID;
    }

    public void removeAllQuizzes()
    {
        for(int x = 0; x<PlayerPrefs.GetInt("QuizCount"); x++)
        {
            removeQuiz(x);
        }

        PlayerPrefs.SetInt("QuizCount", 0);
    }

    public void removeQuiz(int index)
    {
        PlayerPrefs.SetString("Quiz " + index, "");
    }

    public void addClass()//Classroom c
    {

    }

    public void removeClass(int index)
    {

    }

    public void addUser(User u)
    {

    }

    public int requestNewCurrentQuiz(int index)
    {
       
        if (index < PlayerPrefs.GetInt("QuizCount")){
            currentQuiz = index;
            Debug.Log("current quiz: " + currentQuiz);
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public int requestCurrentQuiz()
    {
        return currentQuiz;
    }

    private void makeSampleQuiz()
    {

        QuizStruct myQuiz;
        int numQuestions = 12;
        if (!JsonUtility.FromJson<QuizStruct>(PlayerPrefs.GetString("Quiz 0")).name.Equals("Basic History Quiz"))
        {
            myQuiz = new QuizStruct(0);
        }
        else
        {
            myQuiz = new QuizStruct(PlayerPrefs.GetInt("QuizCount"));
        }

        double[] questionTime = new double[numQuestions];
        string[] questionText = new string[numQuestions];
        string[][] questionAnswers = new string[numQuestions][];
        int[] questionCorrectIndex = new int[numQuestions];


        for(int x = 0; x < numQuestions; x++){
            questionTime[x] = 8.0;
        }

        questionText[0] = "Who was the first man to walk on the moon?";
        questionAnswers[0] = new string[4];
        questionAnswers[0][0] = "Louis Armstrong";
        questionAnswers[0][1] = "Lance Armstrong";
        questionAnswers[0][2] = "Neil Armstrong";
        questionAnswers[0][3] = "Arnold Armstrong";
        questionCorrectIndex[0] = 2;

        questionText[1] = "In which country does the Eiffel Tower reside?";
        questionAnswers[1] = new string[4];
        questionAnswers[1][0] = "Germany";
        questionAnswers[1][1] = "Italy";
        questionAnswers[1][2] = "France";
        questionAnswers[1][3] = "England";
        questionCorrectIndex[1] = 1;

        questionText[2] = "Who fought in the American Civil War?";
        questionAnswers[2] = new string[4];
        questionAnswers[2][0] = "Japan and China";
        questionAnswers[2][1] = "America and Canada";
        questionAnswers[2][2] = "American Colonies and England";
        questionAnswers[2][3] = "The North and the South";
        questionCorrectIndex[2] = 3;

        questionText[3] = "What famous philosopher wrote on the basic human rights of 'life, liberty, and property?'";
        questionAnswers[3] = new string[4];
        questionAnswers[3][0] = "Socrates";
        questionAnswers[3][1] = "John Locke";
        questionAnswers[3][2] = "Aristotle";
        questionAnswers[3][3] = "Plato";
        questionCorrectIndex[3] = 1;

        questionText[4] = "The United States, Russia, and North Korea are the only countries with nuclear weapons";
        questionAnswers[4] = new string[2];
        questionAnswers[4][0] = "True";
        questionAnswers[4][1] = "False";
        questionCorrectIndex[4] = 1;

        questionText[5] = "The tallest building in the world is in North America";
        questionAnswers[5] = new string[2];
        questionAnswers[5][0] = "True";
        questionAnswers[5][1] = "False";
        questionCorrectIndex[5] = 1;

        questionText[6] = "Which of these is not a continent?";
        questionAnswers[6] = new string[8];
        questionAnswers[6][0] = "Africa";
        questionAnswers[6][1] = "North America";
        questionAnswers[6][2] = "South America";
        questionAnswers[6][3] = "Europe";
        questionAnswers[6][4] = "Asia";
        questionAnswers[6][5] = "Antarctica";
        questionAnswers[6][6] = "Australia";
        questionAnswers[6][7] = "Central America";
        questionCorrectIndex[6] = 7;

        questionText[7] = "Who is credited with the invention of the light bulb?";
        questionAnswers[7] = new string[4];
        questionAnswers[7][0] = "Ben Franklin";
        questionAnswers[7][1] = "Thomas Edison";
        questionAnswers[7][2] = "Nikola Tesla";
        questionAnswers[7][3] = "Albert Einstein";
        questionCorrectIndex[7] = 1;

        questionText[8] = "Which famous city was demolished by a volcano?";
        questionAnswers[8] = new string[4];
        questionAnswers[8][0] = "Pompeii";
        questionAnswers[8][1] = "Roanoke";
        questionAnswers[8][2] = "Atlantis";
        questionAnswers[8][3] = "Rome";
        questionCorrectIndex[8] = 0;

        questionText[9] = "Which Asian country's legitimacy as a nation is disputed?";
        questionAnswers[9] = new string[4];
        questionAnswers[9][0] = "Thailand";
        questionAnswers[9][1] = "Singapore";
        questionAnswers[9][2] = "Taiwan";
        questionAnswers[9][3] = "South Korea";
        questionCorrectIndex[9] = 2;

        questionText[10] = "Who won WW2?";
        questionAnswers[10] = new string[3];
        questionAnswers[10][0] = "Axis Powers";
        questionAnswers[10][1] = "Allied Powers";
        questionAnswers[10][2] = "Central Powers";
        questionCorrectIndex[10] = 1;

        questionText[11] = "Which people group is credited with creation of the first written language?";
        questionAnswers[11] = new string[4];
        questionAnswers[11][0] = "The Romans";
        questionAnswers[11][1] = "The Chinese";
        questionAnswers[11][2] = "The Mesopotamians";
        questionAnswers[11][3] = "The Phoenicians";
        questionCorrectIndex[11] = 3;

        myQuiz.name = "Basic History Quiz";
        for(int x = 0; x<numQuestions; x++)
        {
            QuestionStruct q = new QuestionStruct(questionText[x]);
            for (int y = 0; y < questionAnswers[x].Length; y++) {
                if (questionCorrectIndex[x] == y)
                {
                    q.addAnswer(questionAnswers[x][y], true);
                }
                else
                {
                    q.addAnswer(questionAnswers[x][y], false);
                }
            }
            myQuiz.questions.Add(q);
        }

        PlayerPrefs.SetString("Quiz " + myQuiz.quizID, JsonUtility.ToJson(myQuiz));
        PlayerPrefs.SetInt("QuizCount", PlayerPrefs.GetInt("QuizCount") + 1);
    }

}
