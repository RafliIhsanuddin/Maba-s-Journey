using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DTPanitiaPulang : MonoBehaviour
{

    [SerializeField] private DMPanitiaPulang dialogManajer;
    [SerializeField] private GameObject dialogPulang;



    [SerializeField] private GameObject tandaTanya;

    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private Transform skala;



    private bool triggered;

    [SerializeField] private PlayerMovement movementScript;






    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered ) {
            dialogManajer.TriggerStartDialog();
            triggered = true;
        }
    }*/
    




    void Update()
    {

        if (dialogPulang.activeSelf)
        {
            Debug.Log("ada");
        }
        else
        {
            Debug.Log("Hilang");
        }



        Debug.Log("Anjing");


        if (tandaTanya.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                playerInput.enabled = false;
                playerInput.GetComponent<PlayerInput>().enabled = false;
                movementScript.MoveToPositionPanitiaPulang();
                //Debug.Log("Z key pressed");
                
                tandaTanya.SetActive(false);
                



            }
        }

        if (movementScript.PutarbicaraPanitiaPulang)
        {
            movementScript.PutarbicaraPanitiaPulang = false;
            Vector3 currentScale = skala.transform.localScale;
            skala.transform.localScale = new Vector3(0.5f, currentScale.y, currentScale.z);
            //Debug.Log("bicara");
            startDialog();
        }
        //Debug.Log(movementScript.Putarbicara);

    }
    //Debug.Log(movementScript.putarbicara);
    





    private IEnumerator StartDialogWithDelay()
    {
        //playerInput.enabled = false;

        


        yield return new WaitForSeconds(1.8f);
        
        startDialog();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.CompareTag("Player")) // Replace "YourTag" with the appropriate tag for the object you want to trigger this
        {
            Debug.Log("Trigger entered");
            //tandaTanya.SetActive(true);
            if (dialogPulang.activeSelf)
            {
                tandaTanya.SetActive(true);
                //Debug.Log("ada");
            }
            /*else
            {
                Debug.Log("tidak ada");
            }*/

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