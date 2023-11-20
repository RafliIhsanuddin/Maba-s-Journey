using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MematikanAnimasi : MonoBehaviour
{

    [SerializeField] private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimator.SetBool("isWalking", false);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimator.SetBool("isWalking", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
