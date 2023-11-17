using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MountainScene : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Kampus");
    }

}
