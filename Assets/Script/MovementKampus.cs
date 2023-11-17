using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class MovementKampus : MonoBehaviour
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

        if (!interacting) {
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
    }

    public void NotRun()
    {
        myAnimator.SetBool("isWalking", false);
    }


    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isWalking", playerHasHorizontalSpeed);
    }


    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(0.5f * Mathf.Sign(myRigidbody.velocity.x), 0.5f);
        }

    }
}
