using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimationFade : MonoBehaviour
{
    Animator animator;
    SpriteRenderer SR;
    float moveInputX;

    public bool ledgeDetected;

    [SerializeField] Vector2 offset1;
    [SerializeField] Vector2 offset2;

    Vector2 climbBegunPosition;
    Vector2 climbOverPosition;

    bool canGrabLedge = true;
    bool canClimb;
    public int num;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    } 
    private void Update()
    {
        moveInputX = Input.GetAxisRaw("Horizontal");
        Flip();
        if(moveInputX != 0)
        {
            animator.SetBool("walk", true);
        }
        else if(moveInputX ==0)
        {
            animator.SetBool("walk", false);
        }
        CheckForLedge();
        animator.SetBool("canClimb", canClimb);
        //Debug.Log(ledgeDetected);
    }

    void Flip()
    {
        if (moveInputX < 0)
        {
            SR.flipX = true;
        }
        else if (moveInputX > 0)
        {
            SR.flipX = false;            
        }
    }
    
    void CheckForLedge()
    {
        if(ledgeDetected && canGrabLedge)
        {            
            canGrabLedge = false;

            Vector2 ledgePosition = GetComponentInChildren<Ledge>().transform.position;

            climbBegunPosition = ledgePosition + offset1;
            climbOverPosition = ledgePosition + offset2;

            canClimb =  true;
        }
        if (canClimb)
            transform.position = climbBegunPosition;
    }
    void LedgeClimbOver()
    {
        canClimb = false;
        transform.position = climbOverPosition;
        Invoke("AllowLedgeGrab", .1f);
        ledgeDetected = false;
    }

    void AllowLedgeGrab() => canGrabLedge = true ;
}

    
