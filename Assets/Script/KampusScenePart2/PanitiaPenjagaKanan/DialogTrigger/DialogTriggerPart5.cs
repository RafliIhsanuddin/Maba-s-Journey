using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerPart5 : MonoBehaviour
{


    [SerializeField] private GameObject Player;

    [SerializeField] private PanitiaPenjagaDialogSelesai1 dialogPanitiaPenjaga;

    private bool triggered;

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !triggered){
            dialogPanitiaPenjaga.TriggerStartDialog();
            triggered = true;
        }
    }*/


    private void Start()
    {


    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !triggered)
        {
            dialogPanitiaPenjaga.TriggerStartDialog();
            triggered = true;

            // Mengubah skala x dari objek Player menjadi 0.5
            Vector3 currentScale = Player.transform.localScale;
            Player.transform.localScale = new Vector3(0.5f, currentScale.y, currentScale.z);
        }
        /*else if (other.CompareTag("Player") && triggered)
        {
            // Jika karakter terkena trigger lagi, reset status triggered
            triggered = false;
        }*/

        /*if (other.CompareTag("Player"))
        {
            dialogPanitiaPenjaga.TriggerStartDialog();
        }*/

        //GetComponent<DialogTriggerPart3>().enabled = false;
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = false;
        }
    }



    /*private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !triggered)
        {
            dialogPanitiaPenjaga.TriggerStartDialog();
            triggered = true;

            // Mengubah skala x dari objek Player menjadi 0.5
            Vector3 currentScale = Player.transform.localScale;
            Player.transform.localScale = new Vector3(0.5f, currentScale.y, currentScale.z);
        }
        else if (other.CompareTag("Player") && triggered)
        {
            // Jika karakter terkena trigger lagi, reset status triggered
            triggered = false;
        }

        *//*if (other.CompareTag("Player"))
        {
            dialogPanitiaPenjaga.TriggerStartDialog();
        }*//*
    }*/


    /*IEnumerator EnableTriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(true);
    }
*/

}
