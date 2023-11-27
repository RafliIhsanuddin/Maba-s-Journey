using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;
    [SerializeField] TMP_InputField Jawaban;

    QuizTimer timer;

    bool hasAnsweredEarly;


    void Start()
    {
        timer = FindObjectOfType<QuizTimer>();
        SetQuestionText();
    }


    


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckAnswer();
        }

        /*if (timer.LoadNextQuestion)
        {
            SetQuestionText();
            timer.ResetTimer();
        }*/
    }


    void SetQuestionText()
    {
        if(questions.Count > 0)
        {
            GetRandomQuestion();
            questionText.text = currentQuestion.GetQuestion();
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];




        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }

    }

    public void CheckAnswer()
    {
        string inputText = Jawaban.text.Trim();
        string correctAnswer = currentQuestion.GetCorrectAnswer().Trim();

        // Mengabaikan perbedaan huruf besar-kecil
        if (inputText.ToLower() == correctAnswer.ToLower())
        {
            Debug.Log("Jawaban Benar!");
        }
        else
        {
            Debug.Log("Jawaban Salah.");
        }
        timer.ResetTimer();
    }


}
