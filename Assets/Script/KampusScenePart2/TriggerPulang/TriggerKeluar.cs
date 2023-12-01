using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKeluar : MonoBehaviour
{


    [SerializeField] private GameObject Player;



    [SerializeField] private GameObject Pilihan;

    [SerializeField] private GameObject PilihanController;

    private bool triggered;

    [SerializeField] private PlayerMovement movementScript;

    [SerializeField] private ChoiceKeluarKampus2 choice;


    [SerializeField] private Transform skala;


    // Start is called before the first frame update
    void Start()
    {
        //PilihanController.SetActive(false);
        //Pilihan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (movementScript.PutarbicaraKeluar)
        {
            //Debug.Log(movementScript.PutarbicaraKeluar);
            movementScript.PutarbicaraKeluar = false;
            Vector3 currentScale = skala.transform.localScale;
            skala.transform.localScale = new Vector3(0.5f, currentScale.y, currentScale.z);
            movementScript.ToggleIntercation();
            /*if (triggered)
            {
                triggered = false;


            }*/
        }
        Debug.Log(movementScript.PutarbicaraKeluar);
    }




    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !triggered)
        {
            PilihanController.SetActive(true);
            Pilihan.SetActive(true);
            triggered = true;

            movementScript.NotRun();
            movementScript.ToggleIntercation();

            Vector3 currentScale = Player.transform.localScale;
            Player.transform.localScale = new Vector3(0.5f, currentScale.y, currentScale.z);

        }

    }



    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player") && triggered)
        {
            PilihanController.SetActive(false);
            Pilihan.SetActive(false);
            /*if (Pilihan != null && PilihanController != null && choice.SelesaiTrigger == true)
            {
                PilihanController.SetActive(false);
                Pilihan.SetActive(false);
            }*/
            triggered = false;
        }


    }





}
