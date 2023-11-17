using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Transactions;

public class DialogManagerB : MonoBehaviour
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

    private int soundnumberPlayer;
    private int soundnumberNpc;


    private PlayerMovement movementScript;


    private void Start()
    {
        
        movementScript = FindAnyObjectByType<PlayerMovement>();
        StartCoroutine(StartDialog());
    }


    private void Update()
    {
        if (playerContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TriggerContinueNpcDialog();
            }
        }

        if (npcContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TriggerContinuePlayerDialog();
            }
        }
    }



    public IEnumerator StartDialog()
    {

        
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

        playerContinueButton.SetActive(true);
          
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
        npcContinueButton.SetActive(true);
    }


    private IEnumerator ContinuePlayerDialog()
    {
        npcDialogText.text = string.Empty;

        npcSpeechBubbleAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        playerDialogText.text = string.Empty;

        PlayerSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        

        
        if (playerIndex < playerDialogSentences.Length - 1) {
            if(dialogStart)
            {
                playerIndex++;

            }
            else
            {
                dialogStart = true;
            }
            playerDialogText.text = string.Empty;
            StartCoroutine (TypePlayerDialog());
            
        }

        
    }


    private IEnumerator ContinueNpcDialog()
    {

        playerDialogText.text = string.Empty;

        PlayerSpeechBubbleAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        npcDialogText.text = string.Empty;

        npcSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        

        if (npcIndex < npcDialogSentences.Length - 1)
        {
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

    }


    public void TriggerContinuePlayerDialog()
    {

        npcContinueButton.SetActive(false);
        if (playerIndex >= playerDialogSentences.Length - 1)
        {
            npcDialogText.text = string.Empty;

            npcSpeechBubbleAnimator.SetTrigger("Close");
        }
        else
        {
            StartCoroutine(ContinuePlayerDialog());
        }
        

    }

    public void TriggerContinueNpcDialog()
    {

        playerContinueButton.SetActive(false);
        if (npcIndex >= npcDialogSentences.Length - 1)
        {
            playerDialogText.text = string.Empty;

            PlayerSpeechBubbleAnimator.SetTrigger("Close");
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
