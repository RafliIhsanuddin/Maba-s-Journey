using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAuto : MonoBehaviour
{



    private PlayerMovementAuto movementScript;

    

    private void Start()
    {


        movementScript = FindObjectOfType<PlayerMovementAuto>();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            movementScript.MoveToPositionPenjaga();

            // Mengubah skala x dari objek Player menjadi 0.5

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
    }



    
}
