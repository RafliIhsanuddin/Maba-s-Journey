using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int correctAnwers = 0;
    int questionsSeen = 0;



    public int GetCorrectAnswers()
    {
        return correctAnwers;
    }

    public void incrementCorrectAnswers()
    {
        correctAnwers++;
    }

    public int GetQuestionSeen()
    {
        return questionsSeen;
    }

    public void IncrementQuestionSeen()
    {
        questionsSeen++;
    }

    
}
