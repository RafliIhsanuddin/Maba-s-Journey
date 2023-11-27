using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizMudah : MonoBehaviour
{


    [SerializeField] Question[] quesList = new Question[2];
    [SerializeField] TextMeshProUGUI questionTxt;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] float skorPerSoal = 20f;
    [SerializeField] TMP_InputField Jawaban;


    [System.Serializable]
    class Question
    {
        [TextArea]
        public string questionTxt;
        public string answer;
    }

    int soalKe = 0;
    float skor = 0;

    QuizTimer timer;

    private bool playerAnswered = false;




    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<QuizTimer>();

        TampilSoal();

        Jawaban.onEndEdit.AddListener(delegate { CekJawaban(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TampilSoal()
    {
        questionTxt.text = quesList[soalKe].questionTxt;
        scoreTxt.text = skor.ToString();
        timer.ResetTimer();
    }



    public void GoToNextQuestion()
    {
        if (soalKe < quesList.Length - 1)
        {
            soalKe += 1;
            
        }
        else
        {
            Debug.Log("Quiz Selesai");
            Jawaban.text = "Quiz Selesai";
            Jawaban.enabled = false;
        }
        TampilSoal();
    }


    /*void random()
    {
        for (int i = 0; i < quesList.Length; i++)
        {
            Question simpanan = quesList[i];
            int acakan = Random.Range(0, quesList.Length);
            quesList[i] = quesList[acakan];
            quesList[acakan] = simpanan;
        }
    }*/


    public void CekJawaban()
    {
        string inputText = Jawaban.text.Trim();

        if (quesList[soalKe].answer.ToLower() == inputText.ToLower())
        {
            skor += skorPerSoal;
        }

        Jawaban.text = "";

        if (!timer.isDone) // Hanya pindah ke soal selanjutnya jika timer belum habis
        {
            GoToNextQuestion();
        }


    }
}
