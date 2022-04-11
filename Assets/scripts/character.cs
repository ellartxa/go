using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  abstract  class NewBehaviourScript : MonoBehaviour
{
    enemy enemy;
    public GameObject hintprofab;
    public float starthealthy = 5;
    public Hitpoints nowhealthy;
    public float maxhealthy =10;
    public Hitpoints nowmp;
    public float maxmp =20;
    public int startcoin = 0;
    public Hitpoints nowcoin;
    public Hitpoints nowenemyhealthy;
    public GameObject blood;
    public AudioClip audio1;//Ω«…´ ‹…À
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    virtual public void characterdie()
    {
        if (blood) 
        {
            Instantiate(blood, transform.position, Quaternion.identity);
        
        }
            Destroy(gameObject);
          
}
    virtual public  IEnumerator  healthydamage(float interval,float damageamount)
    {
        while (true)
        {
            nowhealthy.healthyvalue -= damageamount;
            StartCoroutine(damagecolor());
            print("damage" + damageamount + nowhealthy.healthyvalue);
            if (nowhealthy.healthyvalue <= float.Epsilon)
            {
                print(false);
                hintprofab.SetActive(true);
                hintprofab.GetComponent<Canvas>().enabled = true;
                characterdie();
                Time.timeScale = 0;
                break;
            }
            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
 
        }
    }
    virtual public void enemydamage(float damageamount) 
    {
        enemy = GameObject.FindGameObjectWithTag("enemys").GetComponent<enemy>();
        nowenemyhealthy.enemyvalue-= damageamount;
        print("damage" + damageamount + nowhealthy.healthyvalue);
        if (nowhealthy.healthyvalue <= float.Epsilon)
        {
            Destroy(enemy);
            
        }
    }
    public IEnumerator damagecolor() 
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.11f);
        GetComponent<SpriteRenderer>().color = Color.white;


    }
    public IEnumerator audio() 
    {
       
            if (audio1 != null)
            {
                audioSource.clip = audio1;
                audioSource.Play();
            }
            yield return new WaitForSeconds(1f);
             if (audio1 != null)
            {
            audioSource.clip = audio1;
            audioSource.Play();
            }

    }
  
}
                  