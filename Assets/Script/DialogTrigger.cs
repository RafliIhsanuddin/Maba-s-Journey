using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    [SerializeField] private DialogManagerB dialogManajer;



    [SerializeField] private GameObject tandaTanya;



    private bool triggered;




    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered ) {
            dialogManajer.TriggerStartDialog();
            triggered = true;
        }
    }*/








    private void Update()
    {
        if (tandaTanya.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                Debug.Log("Z key pressed");
                tandaTanya.SetActive(false);
                startDialog();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.CompareTag("Player")) // Replace "YourTag" with the appropriate tag for the object you want to trigger this
        {
            Debug.Log("Trigger entered");
            tandaTanya.SetActive(true);
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
