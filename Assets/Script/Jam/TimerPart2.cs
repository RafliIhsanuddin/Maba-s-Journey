using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPart2 : MonoBehaviour
{


    [SerializeField] float TimeToComplete = 5f;
    float timerValue;

    private float fillFraction;

    public bool isDone = false;


    [SerializeField] Image TimerImage;
    GameManager LevelManager;



    // Start is called before the first frame update
    private void Awake()
    {
        LevelManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        timerValue = TimeToComplete;
    }

    // Update is called once per frame
    void Update()
    {
        TimerImage.fillAmount = fillFraction;
        UpdateTimer();
    }


    void UpdateTimer() {


        if (!isDone)
        {
            timerValue -= Time.deltaTime;

            if (timerValue <= 0)
            {
                isDone = true;
                timerValue = 0;
                //Debug.Log("Selesai");
                LevelManager.Kalah();
            }

            fillFraction = timerValue / TimeToComplete;
            //Debug.Log(isDone + " : " + timerValue + " = " + fillFraction);
        }

    }






    public void ResetTimer()
    {
        timerValue = TimeToComplete;
        isDone = false;
        fillFraction = 1f; // Reset fill fraction to full
    }






}
