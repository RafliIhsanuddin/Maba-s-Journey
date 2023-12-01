using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerKiri : MonoBehaviour
{

    [SerializeField] private GameObject Player;



    [SerializeField] private GameObject Pilihan;

    [SerializeField] private GameObject PilihanController;

    private bool triggered;

    [SerializeField] private MovementFirstScene movementScript;


    [SerializeField] private Transform skala;






    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {


        PilihanController.SetActive(false);
        Pilihan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(movementScript.Putarbicara);
        if (movementScript.Putarbicara)
        {
            movementScript.Putarbicara = false;
            Vector3 currentScale = skala.transform.localScale;
            skala.transform.localScale = new Vector3(-0.5f, currentScale.y, currentScale.z);
            movementScript.ToggleIntercation();
            /*if (!triggered)
            {
                triggered = true;


            }*/
        }

        //Debug.Log(movementScript.Putarbicara);
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
            Player.transform.localScale = new Vector3(-0.5f, currentScale.y, currentScale.z);
            
        }
        
    }


    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            if (Pilihan != null && PilihanController != null)
            {
                PilihanController.SetActive(false);
                Pilihan.SetActive(false);
            }
            triggered = false;
        }
        
        
    }


}
