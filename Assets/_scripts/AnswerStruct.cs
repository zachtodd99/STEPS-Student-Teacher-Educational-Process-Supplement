using System;

[Serializable]
public class AnswerStruct {
    public string text;
    public bool isCorrect;

    public AnswerStruct()
    {
        text = "";
        isCorrect = false;
    }

    public AnswerStruct(string inputText)
    {
        text = inputText;
        isCorrect = false;
    }

    public AnswerStruct(string inputText, bool inputIsCorrect)
    {
        text = inputText;
        isCorrect = inputIsCorrect;
    }
}
