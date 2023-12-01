using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] float runSpeed = 10f;

    private bool interacting;

    Vector2 moveInput;

    Rigidbody2D myRigidbody;

    Transform skala;


    //DialogTriggerSatriya trigerSatriya;


    //[SerializeField] private DialogManagerSatriya dialogManagerSatriya;


    private bool putarbicara;

    public bool Putarbicara
    {
        get { return putarbicara; }
        set { putarbicara = value; }
    }




    private bool putarbicaraAnra;

    public bool PutarbicaraAnra
    {
        get { return putarbicaraAnra; }
        set { putarbicaraAnra = value; }
    }



    private bool putarbicaraSupri;

    public bool PutarbicaraSupri
    {
        get { return putarbicaraSupri; }
        set { putarbicaraSupri = value; }
    }





    private bool putarbicaraPanitiaPulang;

    public bool PutarbicaraPanitiaPulang
    {
        get { return putarbicaraPanitiaPulang; }
        set { putarbicaraPanitiaPulang = value; }
    }



    private bool putarbicaraKeluar;

    public bool PutarbicaraKeluar
    {
        get { return putarbicaraKeluar; }
        set { putarbicaraKeluar = value; }
    }




    [SerializeField] private PlayerInput playerInput;

    [SerializeField] Animator myAnimator;


    [SerializeField] private Transform target;


    [SerializeField] private Transform targetSatriya;

    [SerializeField] private Transform targetAnra;


    [SerializeField] private Transform targetSupri;

    [SerializeField] private Transform PanitiaPulang;


    [SerializeField] private Transform Keluar;

    private bool isMoving;


    //public event Action OnMoveToPositionComplete;






    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        skala = GetComponent<Transform>();
        //trigerSatriya = GetComponent<DialogTriggerSatriya>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!interacting)
        {
            playerInput.enabled = true;
            Run();
            FlipSprite();
        }

    }

    public void ToggleIntercation()
    {
        interacting = !interacting;
    }


    public void InputActive()
    {
        playerInput.enabled = true;
    }

    

    void OnMove(InputValue value)
    {
         moveInput = value.Get<Vector2>();
         //Debug.Log(moveInput);
    }

     
    void Run()
    {

        Vector2 playerVelocity = new Vector2(moveInput.x*runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isWalking", playerHasHorizontalSpeed);
    }

    public void NotRun()
    {
        myAnimator.SetBool("isWalking", false);
        playerInput.enabled = false;
        myRigidbody.velocity = Vector2.zero;
    }


    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(0.5f * Mathf.Sign(myRigidbody.velocity.x), 0.5f);
        }


    }


    /*public void methodBaru()
    {

    }*/


    public IEnumerator MoveToPositionCoroutine(Vector2 targetPosition)
    {
        // Set isWalking to true before moving


        

        

        // Move the player to the target position
        while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
            float horizontalMovement = Mathf.Sign(targetPosition.x - transform.position.x);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, runSpeed * Time.deltaTime);

            // Flip the sprite based on the direction of movement
            transform.localScale = new Vector2(0.5f * horizontalMovement, 0.5f);

            myAnimator.SetBool("isWalking", true);

            playerInput.enabled = false;

            yield return null;
        }

        // Set isWalking to false after reaching the target position
        myAnimator.SetBool("isWalking", false);


        //OnMoveToPositionComplete?.Invoke();

        // Trigger the dialog after completing the movement
        //trigerSatriya.startDialog();


        //dialogManagerSatriya.TriggerStartDialog();

        //isMoving = false;
    }

    public void MoveToPositionPenjaga()
    {

        Debug.Log("MoveToPositionPenjaga Called");
        Vector2 targetPosition = target.position;

        // Stop any existing coroutine before starting a new one
        StopAllCoroutines();

        // Start the coroutine to move to the target position
        StartCoroutine(MoveToPositionCoroutine(targetPosition));
    }



    public IEnumerator MoveToPositionCorSatriya(Vector2 targetPosition)
    {
        // Set isWalking to true before moving


        // Move the player to the target position
        while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
            float horizontalMovement = Mathf.Sign(targetPosition.x - transform.position.x);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, runSpeed * Time.deltaTime);

            // Flip the sprite based on the direction of movement
            transform.localScale = new Vector2(0.5f * horizontalMovement, 0.5f);

            myAnimator.SetBool("isWalking", true);

            playerInput.enabled = false;

            yield return null;
        }

        Vector3 currentScale = skala.transform.localScale;
        skala.transform.localScale = new Vector3(-0.5f, currentScale.y, currentScale.z);

        putarbicara = true;

        // Set isWalking to false after reaching the target position
        myAnimator.SetBool("isWalking", false);
    }

    public void MoveToPositionSatriya()
    {
        Vector2 targetPosition = targetSatriya.position;

        // Stop any existing coroutine before starting a new one
        StopAllCoroutines();

        // Start the coroutine to move to the target position
        StartCoroutine(MoveToPositionCorSatriya(targetPosition));
    }







    public IEnumerator MoveToPositionCorAnra(Vector2 targetPosition)
    {
        // Set isWalking to true before moving


        // Move the player to the target position
        while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
            float horizontalMovement = Mathf.Sign(targetPosition.x - transform.position.x);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, runSpeed * Time.deltaTime);

            // Flip the sprite based on the direction of movement
            transform.localScale = new Vector2(0.5f * horizontalMovement, 0.5f);

            myAnimator.SetBool("isWalking", true);

            playerInput.enabled = false;

            yield return null;
        }

        Vector3 currentScale = skala.transform.localScale;
        skala.transform.localScale = new Vector3(0.5f, currentScale.y, currentScale.z);

        putarbicaraAnra = true;

        // Set isWalking to false after reaching the target position
        myAnimator.SetBool("isWalking", false);
    }

    public void MoveToPositionAnra()
    {
        Vector2 targetPosition = targetAnra.position;

        // Stop any existing coroutine before starting a new one
        StopAllCoroutines();

        // Start the coroutine to move to the target position
        StartCoroutine(MoveToPositionCorAnra(targetPosition));
    }

















    public IEnumerator MoveToPositionCorSupri(Vector2 targetPosition)
    {
        // Set isWalking to true before moving


        // Move the player to the target position
        while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
            float horizontalMovement = Mathf.Sign(targetPosition.x - transform.position.x);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, runSpeed * Time.deltaTime);

            // Flip the sprite based on the direction of movement
            transform.localScale = new Vector2(0.5f * horizontalMovement, 0.5f);

            myAnimator.SetBool("isWalking", true);

            playerInput.enabled = false;

            yield return null;
        }

        Vector3 currentScale = skala.transform.localScale;
        skala.transform.localScale = new Vector3(-0.5f, currentScale.y, currentScale.z);

        putarbicaraSupri = true;

        // Set isWalking to false after reaching the target position
        myAnimator.SetBool("isWalking", false);
    }

    public void MoveToPositionSupri()
    {
        Vector2 targetPosition = targetSupri.position;

        // Stop any existing coroutine before starting a new one
        StopAllCoroutines();

        // Start the coroutine to move to the target position
        StartCoroutine(MoveToPositionCorSupri(targetPosition));
    }
















    public IEnumerator MoveToPositionCorPanitiaPulang(Vector2 targetPosition)
    {
        // Set isWalking to true before moving


        // Move the player to the target position
        while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
            float horizontalMovement = Mathf.Sign(targetPosition.x - transform.position.x);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, runSpeed * Time.deltaTime);

            // Flip the sprite based on the direction of movement
            transform.localScale = new Vector2(0.5f * horizontalMovement, 0.5f);

            myAnimator.SetBool("isWalking", true);

            playerInput.enabled = false;

            yield return null;
        }

        Vector3 currentScale = skala.transform.localScale;
        skala.transform.localScale = new Vector3(-0.5f, currentScale.y, currentScale.z);

        putarbicaraPanitiaPulang = true;

        // Set isWalking to false after reaching the target position
        myAnimator.SetBool("isWalking", false);
    }

    public void MoveToPositionPanitiaPulang()
    {
        Vector2 targetPosition = PanitiaPulang.position;

        // Stop any existing coroutine before starting a new one
        StopAllCoroutines();

        // Start the coroutine to move to the target position
        StartCoroutine(MoveToPositionCorPanitiaPulang(targetPosition));

    }


















    public IEnumerator MoveToPositionCorKeluar(Vector2 targetPosition)
    {
        // Set isWalking to true before moving


        // Move the player to the target position
        while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
            float horizontalMovement = Mathf.Sign(targetPosition.x - transform.position.x);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, runSpeed * Time.deltaTime);

            // Flip the sprite based on the direction of movement
            transform.localScale = new Vector2(0.5f * horizontalMovement, 0.5f);

            myAnimator.SetBool("isWalking", true);

            playerInput.enabled = false;

            yield return null;
        }

        Vector3 currentScale = skala.transform.localScale;
        skala.transform.localScale = new Vector3(-0.5f, currentScale.y, currentScale.z);

        putarbicaraKeluar = true;

        // Set isWalking to false after reaching the target position
        myAnimator.SetBool("isWalking", false);
    }

    public void MoveToPositionKeluar()
    {
        Vector2 targetPosition = Keluar.position;

        // Stop any existing coroutine before starting a new one
        StopAllCoroutines();

        // Start the coroutine to move to the target position
        StartCoroutine(MoveToPositionCorKeluar(targetPosition));

    }







}





