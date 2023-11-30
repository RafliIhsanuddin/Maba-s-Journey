using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpanAlurDialog1 : MonoBehaviour
{




    /*[Header("Quiz")]



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

    private DialogTriggerAnra TriggerSebelumAnra;*/



    [Header("Panitia")]

    [SerializeField] private PanitiaPenjagaDialogManajer1 dialogPanitia;
    [SerializeField] private PanitiaPenjagaDialogSelesai1 dialogPanitiaSetelah;
    [SerializeField] private PanitiaPenjagaDialogManajer2 dialogBerhasil;
    [SerializeField] private DMPanitiaPulang PanitiaPulang;


    [SerializeField] private GameObject dialogManajerPanitia1;
    [SerializeField] private GameObject dialogManajerPanitiaSetelah1;
    [SerializeField] private GameObject DialogManajerPanitiaBerhasil;
    [SerializeField] private GameObject DMPanitiaPulang;


    [SerializeField] private GameObject Panitia;

    //private Script1 script1;
    //private Script2 script2;

    private DialogTriggerPart6 TriggerPanitiaBerhasil;

    private DialogTriggerPart5 TriggerSetelahPanitia1;

    private DialogTriggerPart4 TriggerSebelumPanitia1;

    private DTPanitiaPulang TriggerPulang;


    private DTTes Trigger;

    SimpanSkor simpanSkor;







    void Awake()
    {
        /*TriggerSebelum = Satriya.GetComponent<DialogTriggerSatriya>();
        TriggerSetelah = Satriya.GetComponent<DialogTriggerSatriyaSetelah>();



        TriggerSebelum.enabled = true;
        TriggerSetelah.enabled = false;




        TriggerSebelumAnra = Anra.GetComponent<DialogTriggerAnra>();
        TriggerSetelahAnra = Anra.GetComponent<DialogTriggerAnraSetelah>();


        TriggerSebelumAnra.enabled = true;
        TriggerSetelahAnra.enabled = false;*/
        simpanSkor = FindObjectOfType<SimpanSkor>();


        TriggerSebelumPanitia1 = Panitia.GetComponent<DialogTriggerPart4>();
        TriggerSetelahPanitia1 = Panitia.GetComponent<DialogTriggerPart5>();
        TriggerPanitiaBerhasil = Panitia.GetComponent<DialogTriggerPart6>();
        TriggerPulang = Panitia.GetComponent<DTPanitiaPulang>();

        Trigger = Panitia.GetComponent<DTTes>();
        TriggerSebelumPanitia1.GetComponent<DialogTriggerPart5>().enabled = false;


        if (simpanSkor.GetSkor() == 40)
        {
            TriggerSebelumPanitia1.enabled = false;
            TriggerSetelahPanitia1.enabled = false;
            TriggerPanitiaBerhasil.enabled = true;
            TriggerPulang.enabled = false;
            Trigger.enabled = false;
            dialogManajerPanitia1.SetActive(false);
            dialogManajerPanitiaSetelah1.SetActive(false);
            DialogManajerPanitiaBerhasil.SetActive(true);
            DMPanitiaPulang.SetActive(false);
        }
        else
        {
            TriggerSebelumPanitia1.enabled = true;
            TriggerSetelahPanitia1.enabled = false;
            TriggerPanitiaBerhasil.enabled = false;
            TriggerPulang.enabled = false;
            Trigger.enabled = false;
            dialogManajerPanitia1.SetActive(true);
            dialogManajerPanitiaSetelah1.SetActive(false);
            DialogManajerPanitiaBerhasil.SetActive(false);
            DMPanitiaPulang.SetActive(false);
        }

        

        


        
        


        /*simpanSkor.SetSkor(0);*/












        /*script1 = budiGameObject.GetComponent<Script1>();
        script2 = budiGameObject.GetComponent<Script2>();*/




        /*script1.enabled = true;
        script2.enabled = false;*/
    }



    // Start is called before the first frame update
    void Start()
    {
        


        
    }

    // Update is called once per frame
    void Update()
    {

        



        if (dialogPanitia.GetSudahBicara())
        {
            TriggerSebelumPanitia1.enabled = false;
            TriggerSetelahPanitia1.enabled = true;
            TriggerPanitiaBerhasil.enabled = false;
            TriggerPulang.enabled = false;
            Trigger.enabled = false;
            DialogManajerPanitiaBerhasil.SetActive(false);
            dialogManajerPanitia1.SetActive(false);
            dialogManajerPanitiaSetelah1.SetActive(true);
            DMPanitiaPulang.SetActive(false);
        }



        




        if (dialogBerhasil.GetSudahBicara())
        {
            TriggerSebelumPanitia1.enabled = false;
            TriggerSetelahPanitia1.enabled = false;
            TriggerPanitiaBerhasil.enabled = false;
            TriggerPulang.enabled = true;
            Trigger.enabled = true;
            dialogManajerPanitia1.SetActive(false);
            dialogManajerPanitiaSetelah1.SetActive(false);
            DialogManajerPanitiaBerhasil.SetActive(false);
            DMPanitiaPulang.SetActive(true);
        }

        /*if (dialogBerhasil.GetSudahBicara())
        {

        }*/


        //Debug.Log(dialogBerhasil.GetSudahBicara());


        //Debug.Log(dialogPanitia.GetSudahBicara());








    }




}
