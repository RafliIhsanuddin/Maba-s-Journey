using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SupriDT : MonoBehaviour
{

    [SerializeField] private SupriDM dialogManajer;



    [SerializeField] private GameObject tandaTanya;



    private bool triggered;




    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered ) {
            dialogManajer.TriggerStartDialog();
            triggered = true;
        }
    }*/


    [SerializeField] private PlayerMovement movementScript;



    [SerializeField] private Transform skala;





    private void Update()
    {
        if (tandaTanya.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                Debug.Log("Z key pressed");
                tandaTanya.SetActive(false);
                movementScript.MoveToPositionSupri();
            }
        }

        if (movementScript.PutarbicaraSupri)
        {
            movementScript.PutarbicaraSupri = false;
            Vector3 currentScale = skala.transform.localScale;
            skala.transform.localScale = new Vector3(-0.5f, currentScale.y, currentScale.z);
            Debug.Log("bicara");
            startDialog();
        }

    }




    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.CompareTag("Player")) // Replace "YourTag" with the appropriate tag for the object you want to trigger this
        {
            Debug.Log("Trigger entered");
            tandaTanya.SetActive(true);
            triggered = false;
        }



        /*if (other.CompareTag("Player") && !triggered)
        {
            //start dialog
            dialogManajer.TriggerStartDialog();
            triggered = true;
        }*/


    }


    private void OnTriggerExit2D(Collider2D other)
    {
        tandaTanya.SetActive(false);
    }





    public void startDialog()
    {



        if (!triggered)
        {
            //start dialog
            dialogManajer.TriggerStartDialog();
            triggered = true;


        }





        /*if (other.CompareTag("Player") && !triggered)
        {
            //start dialog
            dialogManajer.TriggerStartDialog();
            triggered = true;
        }*/
    }



}
