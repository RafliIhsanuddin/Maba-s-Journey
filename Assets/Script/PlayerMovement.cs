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

    [SerializeField] private PlayerInput playerInput;

    Animator myAnimator;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
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
        myAnimator.SetBool("isWalking", true);

        // Move the player to the target position
        while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, runSpeed * Time.deltaTime);

            // Flip the sprite to face the opposite direction
            transform.localScale = new Vector2(-0.5f, 0.5f);

            yield return null;
        }

        // Set isWalking to false after reaching the target position
        myAnimator.SetBool("isWalking", false);
    }

    public void MoveToPositionPenjaga()
    {
        Vector2 targetPosition = new Vector2(0.2f, transform.position.y);

        // Stop any existing coroutine before starting a new one
        StopAllCoroutines();

        // Start the coroutine to move to the target position
        StartCoroutine(MoveToPositionCoroutine(targetPosition));
    }


}





