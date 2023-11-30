using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpanSkor : MonoBehaviour
{


    int skor;




    private void Awake()
    {
        LoadSkor();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void LoadSkor()
    {
        skor = PlayerPrefs.GetInt("skor", 0);
    }

    // ...

    public void SetSkor(int value)
    {
        skor = value;
        SaveSkor();
    }

    void SaveSkor()
    {
        PlayerPrefs.SetInt("skor", skor);
        PlayerPrefs.Save();
    }

    public int GetSkor()
    {
        return skor;
    }
}
