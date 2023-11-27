using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizTimer : MonoBehaviour
{
    [SerializeField] float TimeToComplete = 5f;
    float timerValue;

    private float fillFraction;

    public bool isDone = false;


    [SerializeField] Image TimerImage;
    GameManager LevelManager;

    QuizMudah quizMudah;



    // Start is called before the first frame update
    private void Awake()
    {
        LevelManager = FindObjectOfType<GameManager>();
        quizMudah = FindObjectOfType<QuizMudah>();
    }

    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        TimerImage.fillAmount = fillFraction;
        UpdateTimer();
    }

    public void ResetTimer()
    {
        timerValue = TimeToComplete;
        isDone = false;
    }

    public void CancelTimer()
    {
        timerValue = 0;   
    }


    void UpdateTimer()
    {


        if (!isDone)
        {
            timerValue -= Time.deltaTime;

            if (timerValue <= 0)
            {
                isDone = true;
                timerValue = 0;
                Debug.Log("Selesai");
                quizMudah.GoToNextQuestion();
            }

            fillFraction = timerValue / TimeToComplete;
            Debug.Log(isDone + " : " + timerValue + " = " + fillFraction);
        }

    }
}
