using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public Animator animator;
    
    private Vector3 direction;


    private void Update()
    {
        //get input from player
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical   = Input.GetAxisRaw("Vertical");

        //creat  vector of the direction
        direction = new Vector3(horizontal, vertical);

        AnimateMovement(direction);
        
    }

    private void FixedUpdate()
    {
        //move the player
        this.transform.position += direction * speed * Time.deltaTime;
    }

    private void AnimateMovement(Vector3 direction)
    {
        if(animator !=null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving",true);

                animator.SetFloat("horizontal",direction.x);
                animator.SetFloat("vertical",direction.y);
            }
            else
            {
                animator.SetBool("isMoving",false);
            }
        }
    }
}
