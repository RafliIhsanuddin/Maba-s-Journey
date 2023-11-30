using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpanAlurDialog : MonoBehaviour
{




    [Header("Quiz")]



    [Header("Satriya")]
    [SerializeField] private DialogManagerSatriya dialogSatriya;
    [SerializeField] private GameObject dialogManajerSatriya;
    [SerializeField] private GameObject dialogManajerSatriyaSetelah;


    [SerializeField] private GameObject Satriya;

    //private Script1 script1;
    //private Script2 script2;

    private DialogTriggerSatriyaSetelah TriggerSetelah;

    private DialogTriggerSatriya TriggerSebelum;


    [Header("Anra")]

    [SerializeField] private DialogManagerAnra dialogAnra;
    [SerializeField] private GameObject dialogManajerAnra;
    [SerializeField] private GameObject dialogManajerAnraSetelah;


    [SerializeField] private GameObject Anra;

    //private Script1 script1;
    //private Script2 script2;

    private DialogTriggerAnraSetelah TriggerSetelahAnra;

    private DialogTriggerAnra TriggerSebelumAnra;



    [Header("Panitia")]

    [SerializeField] private PanitiaPenjagaDialogManajer dialogPanitia;
    [SerializeField] private PanitiaPenjagaDialogSelesai dialogPanitiaSetelah;
    [SerializeField] private GameObject dialogManajerPanitia;
    [SerializeField] private GameObject dialogManajerPanitiaSetelah;


    [SerializeField] private GameObject Panitia;

    //private Script1 script1;
    //private Script2 script2;

    private DialogTriggerPart3 TriggerSetelahPanitia;

    private DialogTriggerPart2 TriggerSebelumPanitia;

    SimpanSkor simpanSkor;







    private bool sudahBicaraValue;
    private bool sudahBicaraAnra;

    void Awake()
    {
        TriggerSebelum = Satriya.GetComponent<DialogTriggerSatriya>();
        TriggerSetelah = Satriya.GetComponent<DialogTriggerSatriyaSetelah>();



        TriggerSebelum.enabled = true;
        TriggerSetelah.enabled = false;




        TriggerSebelumAnra = Anra.GetComponent<DialogTriggerAnra>();
        TriggerSetelahAnra = Anra.GetComponent<DialogTriggerAnraSetelah>();


        TriggerSebelumAnra.enabled = true;
        TriggerSetelahAnra.enabled = false;


        TriggerSebelumPanitia = Panitia.GetComponent<DialogTriggerPart2>();
        TriggerSetelahPanitia = Panitia.GetComponent<DialogTriggerPart3>();

        TriggerSebelumPanitia.enabled = true;
        TriggerSetelahPanitia.enabled = false;

        TriggerSebelumPanitia.GetComponent<DialogTriggerPart3>().enabled = false;


        
        simpanSkor = FindObjectOfType<SimpanSkor>();


        simpanSkor.SetSkor(0);












        /*script1 = budiGameObject.GetComponent<Script1>();
        script2 = budiGameObject.GetComponent<Script2>();*/




        /*script1.enabled = true;
        script2.enabled = false;*/
    }



    // Start is called before the first frame update
    void Start()
    {
        sudahBicaraValue = dialogSatriya.GetSudahBicaraSatriya();
        sudahBicaraAnra = dialogAnra.GetSudahBicaraAnra();
    }

    // Update is called once per frame
    void Update()
    {

        sudahBicaraValue = dialogSatriya.GetSudahBicaraSatriya();
        sudahBicaraAnra = dialogAnra.GetSudahBicaraAnra();
        //Debug.Log(sudahBicaraValue);


        if (sudahBicaraValue)
        {
            TriggerSebelum.enabled = false;
            TriggerSetelah.enabled = true;
            dialogManajerSatriya.SetActive(false);
            dialogManajerSatriyaSetelah.SetActive(true);
        }
        // ... (Lakukan sesuatu dengan sudahBicaraValue jika diperlukan)


        if (sudahBicaraAnra)
        {
            TriggerSebelumAnra.enabled = false;
            TriggerSetelahAnra.enabled = true;
            dialogManajerAnra.SetActive(false);
            dialogManajerAnraSetelah.SetActive(true);
        }


        if(sudahBicaraValue && sudahBicaraAnra) {
            TriggerSebelumPanitia.enabled = false;
            TriggerSetelahPanitia.enabled = true;
            dialogManajerPanitia.SetActive(false);
            dialogManajerPanitiaSetelah.SetActive(true);


        }





        Debug.Log(simpanSkor.GetSkor());








    }



   
}
