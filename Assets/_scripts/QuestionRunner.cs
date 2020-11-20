using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionRunner : MonoBehaviour {

    public string[] questionText;
    public double[] questionTime;
    public string[][] questionAnswers;
    public int[][] questionCorrectArrays;
    public int quizIndex;
    public GameObject answerPrefab;

    private Text questionTextBox;
    private Slider timer;
    private GameObject correctPanel;
    private GameObject incorrectPanel;
    private GameObject timeUpPanel;
    private bool timerRunning;
    public int currentQuestionIndex;
    private GameObject answerPanel;


    private int score;
    private int correctCount;
    private int incorrectCount;
    private int timeExpiredCount;
    private int currentStreak;
    private int maxStreak;
    private double timeToAnswerTotal;
    public QuizStruct myQuizStruct;

	// Use this for initialization
	void Start ()
    {
        incorrectPanel = GameObject.Find("Incorrect Panel");
        correctPanel = GameObject.Find("Correct Panel");
        timeUpPanel = GameObject.Find("Time Up Panel");
        answerPanel = GameObject.Find("AnswerPanel");
        //temporaryValueSetter();

        valueSetter();


        questionTextBox = GameObject.Find("Question").GetComponent<Text>();
        timer = FindObjectOfType<Slider>().GetComponent<Slider>();


        currentQuestionIndex = 0;
        updateQuestionDisplay();
        DontDestroyOnLoad(this.gameObject);

        score = 0;
        correctCount = 0;
        incorrectCount = 0;
        timeExpiredCount = 0;
        currentStreak = 0;
        maxStreak = 0;
        timeToAnswerTotal = 0;

        quizIndex = FindObjectOfType<Application>().GetComponent<Application>().requestCurrentQuiz();




        GameObject.Find("Header Bar").transform.Find("Title").GetComponent<Text>().text = "#1 of " + questionText.Length;
    }


    private void valueSetter()
    {
        myQuizStruct = JsonUtility.FromJson<QuizStruct>(PlayerPrefs.GetString("Quiz " + FindObjectOfType<Application>().GetComponent<Application>().requestCurrentQuiz()));
        int numQuestions = myQuizStruct.questions.Count;
        questionText = new string[numQuestions];
        questionTime = new double[numQuestions];
        questionAnswers = new string[numQuestions][];
        questionCorrectArrays = new int[numQuestions][];
        
        for(int x = 0; x < myQuizStruct.questions.Count; x++)
        {

            questionAnswers[x] = new string[myQuizStruct.questions[x].answers.Count];
            questionCorrectArrays[x] = new int[questionAnswers[x].Length];
            for(int y = 0; y<questionAnswers[x].Length; y++)
            {
                questionAnswers[x][y] = myQuizStruct.questions[x].answers[y].text;
                
                if (myQuizStruct.questions[x].answers[y].isCorrect)
                {
                    questionCorrectArrays[x][y] = 1;
                }
                else
                {
                    questionCorrectArrays[x][y] = 0;
                }
            }
            questionText[x] = myQuizStruct.questions[x].text;
            questionTime[x] = myQuizStruct.questions[x].time;
        }




    }


    /*private void temporaryValueSetter()
    {
        int numQuestions = 12;


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


    }*/

    void updateQuestionDisplay()
    {
        questionTextBox.text = questionText[currentQuestionIndex];
        answerPanel.SetActive(true);

        timeUpPanel.SetActive(false);
        correctPanel.SetActive(false);
        incorrectPanel.SetActive(false);
        timerRunning = true;
        FindObjectOfType<TimerRotate>().pauseRotatingTimer();
        //timer.value = (float)questionTime[currentQuestionIndex];
        timer.value = (float) questionTime[currentQuestionIndex];
        timer.maxValue = timer.value;
        foreach (Transform t in answerPanel.transform)
        {
            GameObject.Destroy(t.gameObject);
        }

        for (int x = 0; x<questionAnswers[currentQuestionIndex].Length; x++)
        {
            
            GameObject a = Instantiate(answerPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
            a.GetComponent<Answer>().index = x;
            a.GetComponentInChildren<Text>().text = questionAnswers[currentQuestionIndex][x];
            a.transform.SetParent(answerPanel.transform, false);
        }

    }

    // Update is called once per frame
    void Update () {

        if (timerRunning)
        {
            if (timer.value <= 0.0)
            {
                chooseAnswer(-1);
            }
            else
            {
                timer.value -= Time.deltaTime;
            }
        }
	}

    public void chooseAnswer(int answerIndex)
    {

        
        timerRunning = false;
        FindObjectOfType<TimerRotate>().pauseRotatingTimer();
        incorrectPanel.SetActive(false);
        correctPanel.SetActive(false);
        timeToAnswerTotal += timer.maxValue - timer.value;
        

        foreach (Transform t in answerPanel.transform)
        {
            t.gameObject.GetComponent<Button>().interactable = false;
        }

        if (answerIndex == -1)
        {
            timeUpPanel.SetActive(true);
            timeExpiredCount++;
            currentStreak = 0;
            for (int x = 0; x < questionCorrectArrays[currentQuestionIndex].Length; x++)
            {
                if (questionCorrectArrays[currentQuestionIndex][x] == 1)
                {
                    answerPanel.transform.GetChild(x).GetComponent<Image>().color = new Color(0, 1, 0);
                }
            }

        }else if (questionCorrectArrays[currentQuestionIndex][answerIndex] == 1)
        {
            correctPanel.SetActive(true);

            for (int x = 0; x < questionCorrectArrays[currentQuestionIndex].Length; x++)
            {
                if (questionCorrectArrays[currentQuestionIndex][x] == 1)
                {
                    answerPanel.transform.GetChild(x).GetComponent<Image>().color = new Color(0, 1, 0);
                }
            }

            score += (int) (timer.value*100);
            correctCount++;
            currentStreak++;
            if (currentStreak > maxStreak)
            {
                maxStreak = currentStreak;
            }
        }
        
        else
        {
            incorrectPanel.SetActive(true);
            incorrectCount++;
            currentStreak = 0;
            for (int x = 0; x < questionCorrectArrays[currentQuestionIndex].Length; x++)
            {
                if (questionCorrectArrays[currentQuestionIndex][x] == 1)
                {
                    answerPanel.transform.GetChild(x).GetComponent<Image>().color = new Color(0, 1, 0);
                }
            }
            answerPanel.transform.GetChild(answerIndex).GetComponent<Image>().color = new Color(1, 0, 0);
        }


        //Invoke("updateQuestion", 4f);
        Invoke("updateQuestion", 2f);
    }

    public void updateQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex > questionText.Length-1)
        {
            FindObjectOfType<LevelManager>().LoadNewScene("QuizResult");
        }
        else { 
            updateQuestionDisplay();

            GameObject.Find("Header Bar").transform.Find("Title").GetComponent<Text>().text = "#" + (currentQuestionIndex+1) + " of " + questionText.Length;
        }
    }


    public void DisplayResults()
    {
        Debug.Log("Quiz Index:" + quizIndex);

        GameObject.Find("Score").GetComponent<Text>().text = "Score: " + score;
        double percentage = ((double) correctCount) /( (double) questionText.Length);
        GameObject.Find("Stats").GetComponent<Text>().text =
            "Correct: " + correctCount +
            "\nIncorrect: " + incorrectCount +
            "\nTime Expired: " + timeExpiredCount +
            "\nPercentage Correct: " + System.Math.Round(percentage*100,2) + "%" + 
            "\nAverage Time: " + (Math.Truncate((timeToAnswerTotal/((double) questionText.Length)) * 100) / 100) + "s" + 
            "\nBest Streak: " + maxStreak;

        GameObject.Find("User").GetComponent<User>().updateQuizRecord(quizIndex,percentage,score);


    }
}
