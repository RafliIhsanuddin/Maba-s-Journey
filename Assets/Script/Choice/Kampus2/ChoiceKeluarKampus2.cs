using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceKeluarKampus2 : MonoBehaviour
{



    float Selection;


    private bool selesaiTrigger;

    public bool SelesaiTrigger
    {
        get { return selesaiTrigger; }
        set { selesaiTrigger = value; }
    }

    [Space(10)]
    [Header("start")]
    public GameObject PlaySprite;
    public GameObject PlaySpriteSelected;



    [Space(10)]
    [Header("Quit")]
    public GameObject QuitSprite;
    public GameObject QuitSpriteSelected;

    /*[Space(10)]
    [Header("Trigger")]
    [SerializeField] TriggerKiri trigger;*/


    GameManager LevelManager;


    [Space(10)]
    [Header("movement")]
    [SerializeField] private PlayerMovement movementScript;



    [Space(10)]
    [Header("Audio")]
    [SerializeField] private AudioSource UIAudioSource;

    private void Awake()
    {
        LevelManager = FindObjectOfType<GameManager>();
    }



    // Start is called before the first frame update
    void Start()
    {
        Selection = 1;
    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.Return))
        {
            UIAudioSource.Play();
            if (PlaySpriteSelected.activeSelf)
            {
                LevelManager.Kampus();
            }

            if (QuitSpriteSelected.activeSelf)
            {
                movementScript.MoveToPositionKeluar();
                selesaiTrigger = true;

            }
        }












        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            UIAudioSource.Play();
            if (Selection <= 2)
            {
                Selection++;
            }


            if (Selection > 2)
            {
                Selection = 1;
            }



        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UIAudioSource.Play();
            if (Selection >= 1)
            {
                Selection--;
            }


            if (Selection < 1)
            {
                Selection = 2;
            }
        }


        if (Selection == 1)
        {
            PlaySprite.SetActive(false);
            PlaySpriteSelected.SetActive(true);
            QuitSprite.SetActive(true);
            QuitSpriteSelected.SetActive(false);
        }


        if (Selection == 2)
        {

            PlaySprite.SetActive(true);
            PlaySpriteSelected.SetActive(false);
            QuitSprite.SetActive(false);
            QuitSpriteSelected.SetActive(true);
        }
    }
}
