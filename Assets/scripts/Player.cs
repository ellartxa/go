using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : NewBehaviourScript
{

   
    public AudioClip audio2;//����
    public AudioClip audio3;//�����
    private AudioSource audioSource;
    public Playerui healthyprofab;//����Ԥ�Ƽ�
    public inventory inventoryprofab;
    Playerui healthy;//�����ʵ��������
    [HideInInspector]
    public inventory inventory;
    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        nowhealthy.healthyvalue = starthealthy ; 
        nowmp.mpvalue = starthealthy;
        nowcoin.coinvalue = startcoin;
       //  healthy = Instantiate(healthyprofab);
        //healthy.Player = this; 
        inventory = Instantiate(inventoryprofab);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("canbepickup"))
        {
           // bool active;
            Item hitpoint = collision.gameObject.GetComponent<consumable>().item;//��ȡitem���临�Ƶ�hitpoint
            if (hitpoint != null)
            {
                bool shoulddisappear = false;
                print("get:" + hitpoint.objectname);
                switch (hitpoint.itemType)
                {
                    case Item.ItemType.COIN:
                        if (audio2 !=null) 
                        {
                            audioSource.clip = audio2;
                            audioSource.Play();
                        }
                        shoulddisappear = adjustCOIN(hitpoint.quantity);
                        break;
                    case Item.ItemType.HEALTHY:
                        if (audio3 != null) 
                        {
                            audioSource.clip = audio3;
                            audioSource.Play();
                        }
                        shoulddisappear = inventory.Additem(hitpoint);
                        //shoulddisappear = adjusthealthy(hitpoint.quantity);
                        break;
                    case Item.ItemType.MP:
                        if (audio3 != null)
                        {
                            audioSource.clip = audio3;
                            audioSource.Play();
                        }
                        shoulddisappear = inventory.Additem(hitpoint);
                        //shoulddisappear = adjustmp(hitpoint.quantity);
                        break;
                    default:
                        break;
                }

                if (shoulddisappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }
            

        }
    }
    public void adjusthealthy(float amount)
    {
        if (nowhealthy.healthyvalue < maxhealthy)
        {
            nowhealthy.healthyvalue = nowhealthy.healthyvalue + amount;
            print("adjusthealthy" + amount + nowhealthy.healthyvalue);
        }
        else
        {
            return;
        }
    }
    public void adjustmp(float amount)
    {
        if (nowmp.mpvalue < maxmp)
        {
            nowmp.mpvalue = nowmp.mpvalue + amount;
            print("adjustmp" + amount + nowmp.mpvalue);
        }
        else 
        {
            return;
        }
      
    }
    public bool adjustCOIN(int amount)
    {
        nowcoin.coinvalue = nowcoin.coinvalue + amount;
        print("adjustmp" + amount + nowcoin.coinvalue);
        return true;
    }
    
}

