using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{

    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private bool PlayerSpeakingFirst;


    [Header("Dialog Text")]
    [SerializeField] private TextMeshProUGUI playerDialogText;
    [SerializeField] private TextMeshProUGUI npcDialogText;


    [Header("Button")]
    [SerializeField] private GameObject playerButtonContinue;
    [SerializeField] private GameObject npcButtonContinue;

    [Header("Animator")]
    [SerializeField] private Animator playerBubbleAnimator;
    [SerializeField] private Animator npcBubbleAnimator;



    private int playerIndex;
    private int npcIndex;


    private float speechBubbleAnimationDelay = 0.6f;

    [Header("Dialog Sentences")]
    [TextArea]
    [SerializeField] private string[] PlayerDialogSentences;
    [TextArea]
    [SerializeField] private string[] npcDialogSentences;


    /*[Header("UI Audio Source")]
    [SerializeField] private AudioSource bubAudioSource;*/

    private MovementKampus playerMovementScript;

    [Header("Bubble GameObject")]
    [SerializeField] private GameObject playerBubble;
    [SerializeField] private GameObject npcBubble;


    private bool dialogStarted;


    private bool PlayerdialogFinished;
    private bool npcdialogFinished;





    void Start()
    {
        playerMovementScript = FindAnyObjectByType<MovementKampus>();
    }

    public void TriggerStartDialog()
    {
        StartCoroutine(StartDialog());
        playerMovementScript.NotRun();
    }


    void Update()
    {

        if (PlayerdialogFinished)
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                TriggerContinueNpcDialog();
            }
        }

        /*if (playerButtonContinue.activeSelf) { 
            if(Input.GetKeyUp(KeyCode.Z)) {
                TriggerContinueNpcDialog();
            }
        }*/

        if(npcdialogFinished) {
            if (Input.GetKeyUp(KeyCode.Z)) { 
                TriggerContinuePlayerDialog();  
            }
        }

        /*if (npcButtonContinue.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                TriggerContinuePlayerDialog();
            }
        }*/
    }


    public IEnumerator StartDialog()
    {

        playerMovementScript.ToggleIntercation();
        if (PlayerSpeakingFirst)
        {
            playerBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            //playerBubble.SetActive(true);
            StartCoroutine(TypePlayerDialog());
        }
        else
        {
            npcBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            //npcBubble.SetActive(true);
            StartCoroutine(TypeNpcDialog());
        }
    }


    private IEnumerator TypePlayerDialog()
    {
        foreach (char letter in PlayerDialogSentences[playerIndex].ToCharArray())
        {
            playerDialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        //playerButtonContinue.SetActive(true);
        PlayerdialogFinished = true;

    }


    private IEnumerator TypeNpcDialog()
    {
        foreach (char letter in npcDialogSentences[npcIndex].ToCharArray())
        {
            npcDialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        //npcButtonContinue.SetActive(true);
        npcdialogFinished = true;



    }


    public IEnumerator ContinuePlayerDialog()
    {

        npcDialogText.text = string.Empty;

        npcBubbleAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        playerDialogText.text = string.Empty;

        playerBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);


        
       //npcBubble.SetActive(false);
        

        if(dialogStarted)
        {
            playerIndex++;
        }
        else
        {
            dialogStarted = true;
        }
            

        StartCoroutine(TypePlayerDialog());
        
        //playerBubble.SetActive(true);
    }

    public IEnumerator ContinueNpcDialog()
    {
        playerDialogText.text = string.Empty;

        playerBubbleAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        npcDialogText.text = string.Empty;

        npcBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);


        
        //playerBubble.SetActive(false);
        

        if (dialogStarted)
        {
            npcIndex++;
        }
        else
        {
            dialogStarted = true;
        }
            
        StartCoroutine(TypeNpcDialog());
        
        //npcBubble.SetActive(true);
    }


    public void TriggerContinuePlayerDialog() {

        //npcButtonContinue.SetActive(false);
        npcdialogFinished = false;


        if (playerIndex >= PlayerDialogSentences.Length - 1)
        {
            npcDialogText.text = string.Empty;
            npcBubbleAnimator.SetTrigger("Close");
            playerMovementScript.ToggleIntercation();
        }
        else
        {
            StartCoroutine(ContinuePlayerDialog());
        }


        
    }

    

    public void TriggerContinueNpcDialog(){

        //playerButtonContinue.SetActive(false);
        PlayerdialogFinished = false;

        if (npcIndex >= PlayerDialogSentences.Length - 1)
        {
            playerDialogText.text = string.Empty;
            playerBubbleAnimator.SetTrigger("Close");
            playerMovementScript.ToggleIntercation();
        }
        else
        {
            StartCoroutine(ContinueNpcDialog());
        }
        
    }







}
