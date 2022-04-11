using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wander : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float waitinterval = 3.0f;
    public float enemywalkspeed = 2.0f;
    private Coroutine moveCoroutine;
    private Vector2 endposition;
    private Animator animator;
    private CircleCollider2D circle;
    private Transform playertranform;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(wanderload());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, endposition, Color.red);
    }
    IEnumerator wanderload()
    {
        while (true)
        {
            endpoint();
            moveCoroutine= StartCoroutine(enemymove());
            yield return new WaitForSeconds(waitinterval);
           
        }
       
    }
    public void endpoint()
    {
        float rad = Random.Range(0, 360); 
        float banjing = Random.Range(2,5);
        rad = rad * Mathf.Deg2Rad;//转弧度
         endposition = rb2d.position + new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * banjing;// 得到任务最终到达的终点

    }
    IEnumerator enemymove()
    {
        float remaindistance = (rb2d.position - endposition).sqrMagnitude;//返回向量的长度
        while(remaindistance > float.Epsilon)
        {
            animator.SetBool("iswalking", true);
            if(playertranform != null) 
            {
                endposition = playertranform.position;
            }
            Vector2 newposition = Vector2.MoveTowards(rb2d.position, endposition, Time.fixedDeltaTime * enemywalkspeed);
            rb2d.MovePosition(newposition);
            yield return new WaitForFixedUpdate();

        }
            animator.SetBool("iswalking", false);
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            playertranform = collision.gameObject.GetComponent<Transform>();
            if (moveCoroutine != null)
            {
                StopCoroutine(enemymove());

            }
            moveCoroutine = StartCoroutine(enemymove());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            animator.SetBool("iswalking",false);
               playertranform = null;
                if (moveCoroutine != null)
                {
                    StopCoroutine(enemymove());
                    moveCoroutine = null;
                 }
           
            


        }
            
    }

}
