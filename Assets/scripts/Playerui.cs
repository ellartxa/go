using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerui : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Hitpoints hitpoints;
    [HideInInspector]
    public Player player;
    public Image healthymeter_a;
    public Image mpmeter_a;
    public Text coinaccount;
    public float Maxhealthy;
    public float Maxmp;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Maxhealthy = 10;
        Maxmp = 20;
    }

    // Update is called once per frame
    void Update()
    {
       
            healthymeter_a.fillAmount = hitpoints.healthyvalue / Maxhealthy;
            mpmeter_a.fillAmount = hitpoints.mpvalue /  Maxmp;
            coinaccount.text = "" + hitpoints.coinvalue;
            if (hitpoints.healthyvalue <= 0) 
            {
                healthymeter_a.fillAmount = 0;
            }
     
        
    }
}
