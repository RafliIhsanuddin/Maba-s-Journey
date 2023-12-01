using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/


    public void FirstScene()
    {
        SceneManager.LoadScene("Mountain Scene");
    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }




    public void Kampus()
    {

        SceneManager.LoadScene("KampusGamePart2Timer");
    }





    public void Kalah()
    {
        SceneManager.LoadScene("Kalah");
    }

    public void Quiz()
    {
        SceneManager.LoadScene("JawabPertanyaan");
    }


    public void Kampus2()
    {
        SceneManager.LoadScene("KampusGamePart2TimerScene2");
    }


    



}
