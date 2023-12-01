using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kalah2 : MonoBehaviour
{

    float Selection;

    [Space(10)]
    [Header("start")]
    public GameObject PlaySprite;
    public GameObject PlaySpriteSelected;



    [Space(10)]
    [Header("Quit")]
    public GameObject QuitSprite;
    public GameObject QuitSpriteSelected;


    GameManager LevelManager;




    [Header("AudioSource")]
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
                LevelManager.Kampus2();
            }

            if (QuitSpriteSelected.activeSelf)
            {
                LevelManager.Quit();
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
