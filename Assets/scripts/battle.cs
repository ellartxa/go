using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle : MonoBehaviour
{
    enemy enemy;
    // Start is called before the first frame update
    //�ӵ��ٶ�
    public float battlespeed = 3.0f;
    //�ӵ�����������
    public float battletime = 3.0f;
    //��ʱʱ��
    private float Basetime = 0.0f;
    public Item attack;
    public GameObject blood;
    void Start()
    {
          attack = gameObject.GetComponent<consumable>().item; 
    }
    private void OnEnable()
    {
        Basetime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * battlespeed * Time.deltaTime);
        Basetime += Time.deltaTime;
        if (Basetime > battletime)
        {
            gameObject.SetActive(false);
        }
    }
    public void characterdie()
    {
        if (blood)
        {
            Instantiate(blood, transform.position, Quaternion.identity);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemys")) 
        {
            enemy = GameObject.FindGameObjectWithTag("enemys").GetComponent<enemy>();
            if (collision is BoxCollider2D) 
            {
                enemy.enemydamage(attack.addquanity);
                enemy.damagecolor();
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                GetComponent<SpriteRenderer>().gameObject.SetActive(false);
                if (enemy.nowenemyhealthy.enemyvalue <= float.Epsilon) 
                {
                    collision.gameObject.SetActive(false);
                    if (blood)
                    {
                        Instantiate(blood, collision.gameObject.transform.position, Quaternion.identity);

                    }
                    enemy.nowenemyhealthy.enemyvalue = 10;
                }
                
          
            }
           
        }
    }
    IEnumerator wait() 
    {
        
            yield return new WaitForSeconds(0.1f); 
    
    }

}


