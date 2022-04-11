using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      //  attackstate();
        movestates();
        movefast();
    }
    private void FixedUpdate()
    {
        charactermove();
    }
    public float movespeed;
    Vector2 move = new Vector2();
    Rigidbody2D rb2d;
    Animator animator;
    Animator anim;
    string animstates="playerattack";
    string animationstates = "Animator state";
    bool movehander = false;
    enum characterstates
    { 
           walkereast = 1,
           walkerwest = 2,
           walkersouth = 3,
           walkernorth = 4,
           walkerideal =5

     }
    enum characterattack 
    {
        playerattackeast = 1,
        playerattackwest = 2,
        playerattackback = 3,
        playerattackfront = 4,
    }
    public void charactermove()
    {   
        if (movehander == false)
        {
            movespeed = 3.0f;
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
            move.Normalize();
            rb2d.velocity = move * movespeed;
        }
        else if (movehander == true) 
        {
            movespeed =8.0f;
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
            move.Normalize();
            rb2d.velocity = move * movespeed;


        }
       
    }
    public void attackstate() 
    {
        if (move.x > 0 && Input.GetMouseButtonDown(0))
        {
            anim.SetInteger(animstates, (int)characterattack.playerattackeast);
        }
        if (move.x < 0 && Input.GetMouseButtonDown(0))
        {
            anim.SetInteger(animstates, (int)characterattack.playerattackwest);
        }
        if (move.y > 0 && Input.GetMouseButtonDown(0))
        {
            anim.SetInteger(animstates, (int)characterattack.playerattackfront);
        }
        if (move.y < 0 && Input.GetMouseButtonDown(0))
        {
            anim.SetInteger(animstates, (int)characterattack.playerattackback);
        }
    }
    public void movestates() {
        if (move.x > 0)
        {
            animator.SetInteger(animationstates, (int)characterstates.walkereast);
        }
        else if (move.x < 0)
        {
            animator.SetInteger(animationstates, (int)characterstates.walkerwest);
        }
        else if (move.y > 0)
        {
            animator.SetInteger(animationstates, (int)characterstates.walkernorth);
        }
        else if (move.y < 0)
        {
            animator.SetInteger(animationstates, (int)characterstates.walkersouth);
        }
        else
        {
            animator.SetInteger(animationstates, (int)characterstates.walkerideal);
        }
    }
    public void movefast() 
    {

        if (movehander == true)
        {
            if (Input.GetButtonDown("Jump1")) 
            {
                movehander = false;
            }
        }
        else if(movehander == false)
        {
            if (Input.GetButtonDown("Jump1"))
            {
                movehander = true;
            }
        }
    }
}
