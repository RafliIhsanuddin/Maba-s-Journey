using System.Collections;
using System.Collections.Generic;
using UnityEngine;








[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]

public class QuestionSO : ScriptableObject
{
    // Start is called before the first frame update

    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string answer;


    public string GetQuestion()
    {
        return question;
    }


    public string GetCorrectAnswer()
    {
        return answer;
    }



    
}
