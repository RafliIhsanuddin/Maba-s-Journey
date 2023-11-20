using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Transactions;

public class DialogManagerAnra : MonoBehaviour
{

    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private bool PlayerSpeakingFirst;

    [Header("Dialog TMP text")]
    [SerializeField] private TextMeshProUGUI playerDialogText;
    [SerializeField] private TextMeshProUGUI npcDialogText;


    [Header("Continue Buttons")]
    [SerializeField] private GameObject playerContinueButton;
    [SerializeField] private GameObject npcContinueButton;


    [Header("UIAudioSource")]
    [SerializeField] private AudioSource UIAudioSource;



    [Header("Animation Controllers")]
    [SerializeField] private Animator PlayerSpeechBubbleAnimator;
    [SerializeField] private Animator npcSpeechBubbleAnimator;



    [Header("Dialog Sentences")]
    [TextArea]
    [SerializeField] private string[] playerDialogSentences;

    [TextArea]
    [SerializeField] private string[] npcDialogSentences;

    private bool dialogStart;

    private int playerIndex;
    private int npcIndex;

    private float speechBubbleAnimationDelay = 0.6f;

    


    private PlayerMovement movementScript;



    private bool PlayerdialogFinished;
    private bool npcdialogFinished;



    private void Start()
    {

        movementScript = FindObjectOfType<PlayerMovement>();
    }

    public void TriggerStartDialog() {

        playerIndex = 0;
        npcIndex = 0;
        dialogStart = false; // Reset dialogStart


        playerDialogText.rectTransform.localScale = new Vector3(0.0697239f,
                                                   playerDialogText.rectTransform.localScale.y,
                                                   playerDialogText.rectTransform.localScale.z);



        StartCoroutine(StartDialog());
        movementScript.NotRun();
    }


    private void Update()
    {

        if (PlayerdialogFinished)
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                TriggerContinueNpcDialog();
            }
        }


        /*if (playerContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                TriggerContinueNpcDialog();
            }
        }*/


        if (npcdialogFinished)
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                TriggerContinuePlayerDialog();
            }
        }



        /*if (npcContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                TriggerContinuePlayerDialog();
            }
        }*/

        

    }



    public IEnumerator StartDialog()
    {

        movementScript.ToggleIntercation();

        


        if (PlayerSpeakingFirst)
        {
            PlayerSpeechBubbleAnimator.SetTrigger("Open");

            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypePlayerDialog());
        } else {
            npcSpeechBubbleAnimator.SetTrigger("Open");

            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeNpcDialog());
        }
    }

    private IEnumerator TypePlayerDialog()
    {

        int totalCharacters = playerDialogSentences[playerIndex].Length;
        int currentCharacterIn = 0;

        foreach (char letter in playerDialogSentences[playerIndex].ToCharArray())
        {
            UIAudioSource.Play();
            playerDialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            currentCharacterIn++;

            // Check if the current character is the last one
            if (currentCharacterIn == totalCharacters)
            {
                // This is the last character, stop the audio source
                UIAudioSource.Stop();
            }
        }

        /*playerContinueButton.SetActive(true);*/
        PlayerdialogFinished = true;

    }

    private IEnumerator TypeNpcDialog()
    {

        int totalCharac = npcDialogSentences[npcIndex].Length;
        int currentCharacterIndex = 0;

        foreach (char letter in npcDialogSentences[npcIndex].ToCharArray())
        {
            UIAudioSource.Play();
            npcDialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            currentCharacterIndex++;

            if (currentCharacterIndex == totalCharac)
            {
                // This is the last character, stop the audio source
                UIAudioSource.Stop();
            }


        }
        /*npcContinueButton.SetActive(true);*/

        npcdialogFinished = true;



    }


    private IEnumerator ContinuePlayerDialog()
    {
        npcDialogText.text = string.Empty;

        npcSpeechBubbleAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        playerDialogText.text = string.Empty;

        PlayerSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        

        
        
        if(dialogStart)
        {
            playerIndex++;

        } else {
            dialogStart = true;
        }
        StartCoroutine (TypePlayerDialog());
            
        

        
    }


    private IEnumerator ContinueNpcDialog()
    {

        playerDialogText.text = string.Empty;

        PlayerSpeechBubbleAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        npcDialogText.text = string.Empty;

        npcSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);




        if (dialogStart)
        {
            npcIndex++;

        }
        else
        {
            dialogStart = true;
        }
        StartCoroutine(TypeNpcDialog());

        




    }


    public void TriggerContinuePlayerDialog()
    {

        /*npcContinueButton.SetActive(false);*/

        npcdialogFinished = false;


        if (playerIndex >= playerDialogSentences.Length - 1)
        {
            npcDialogText.text = string.Empty;

            npcSpeechBubbleAnimator.SetTrigger("Close");

            movementScript.ToggleIntercation();
        }
        else
        {
            StartCoroutine(ContinuePlayerDialog());
        }


        

    }

    public void TriggerContinueNpcDialog()
    {


        /*playerContinueButton.SetActive(false);*/
        PlayerdialogFinished = false;

        if (npcIndex >= npcDialogSentences.Length - 1)
        {
            playerDialogText.text = string.Empty;

            PlayerSpeechBubbleAnimator.SetTrigger("Close");

            movementScript.ToggleIntercation();
        }
        else
        {
            StartCoroutine(ContinueNpcDialog());
        }


        


    }


    // Start is called before the first frame update


    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
