using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementFirstScene : MonoBehaviour
{


    [SerializeField] float runSpeed = 10f;

    private bool interacting;

    Vector2 moveInput;

    Rigidbody2D myRigidbody;

    Transform skala;



    [SerializeField] private PlayerInput playerInput;

    [SerializeField] Animator myAnimator;


    [SerializeField] private Transform target;





    private bool putarbicara;

    public bool Putarbicara
    {
        get { return putarbicara; }
        set { putarbicara = value; }
    }








    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        skala = GetComponent<Transform>();
    }


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



    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
    }


    void Run()
    {

        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
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

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(0.5f * Mathf.Sign(myRigidbody.velocity.x), 0.5f);
        }


    }



    public IEnumerator MoveToPositionCoroutine(Vector2 targetPosition)
    {
        // Set isWalking to true before moving





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

        putarbicara = true;



    }

    public void MoveToPositionKuliah()
    {

        Debug.Log("MoveToPositionPenjaga Called");
        Vector2 targetPosition = target.position;

        // Stop any existing coroutine before starting a new one
        StopAllCoroutines();

        // Start the coroutine to move to the target position
        StartCoroutine(MoveToPositionCoroutine(targetPosition));
    }







}
