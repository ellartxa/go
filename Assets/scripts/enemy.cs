using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : NewBehaviourScript
{
  //  private AudioSource audioSource1;
    Player player;
    //定义一个时间间隔
    public float interval = 1.0f;
    //定义一个伤害量
    [HideInInspector]
    public float damageamount = 1.0f;
    
    private Coroutine damagecoroutine;

    //private void Awake()
    //{
    //    audioSource1 = gameObject.GetComponent<AudioSource>();
    //}
    // Start is called before the first frame update
    void Start()
    {
        
        nowenemyhealthy.enemyvalue = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
      
            if (collision.gameObject.CompareTag("Player"))
            {
                player = collision.gameObject.GetComponent<Player>();
                if (damagecoroutine == null) 
                {
                damagecoroutine = StartCoroutine(player.healthydamage(interval, damageamount));
                StartCoroutine(audio());
                }
                
               
            }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            if (damagecoroutine != null)
            {
                StopCoroutine(damagecoroutine);
                damagecoroutine = null;
            }
        }
    }
}
