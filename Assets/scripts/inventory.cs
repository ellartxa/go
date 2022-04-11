using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public GameObject slotprofab;
    public const int numslots = 5;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        start();
    }

    // Update is called once per frame
    void Update()
    {
        panduan();
    }
   
    //创建对图片的数组
    Image[] itemimage = new Image[numslots];
    //创建连接图片和物品的item
    Item[] item = new Item[numslots];
    //创建物品
    GameObject[] slots = new GameObject[numslots];
    //实例化slot预制件
    Button[] button = new Button[numslots];
    Text[] texts = new Text[numslots];
    public void createslot()
    {
        if (slotprofab != null)
        {
            for (int i = 0; i < numslots; i++)
            {
                GameObject newslot = Instantiate(slotprofab);
                newslot.name = "itemslot+" + i;
                newslot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                slots[i] = newslot;
                itemimage[i] = slots[i].GetComponent<slop>().bgimage;
                texts[i] = slots[i].GetComponent<slop>().quantity;

            }
        }


    }
    public void start()
    {
        createslot();
    }
    public bool Additem(Item toadd)
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (item[i] != null && item[i].itemType == toadd.itemType && toadd.stackable == true)
            {
                item[i].quantity  +=  1;
                slop slotscripts = slots[i].gameObject.GetComponent<slop>();
                Text text = slotscripts.quantity;
                text.enabled = true;
                text.text = item[i].quantity.ToString();
                return true;
            }
            if (item[i] == null)
            {
                item[i] = Instantiate(toadd);
                item[i].quantity = 1;
                texts[i].text = item[i].quantity.ToString();
                toadd = item[i];
                //item[i] = toadd; 
                itemimage[i].sprite = toadd.sprite;
                itemimage[i].enabled = true;
                return true;


            }
        }


        return false;
    }
    public void panduan()
    {
        int index;
        if (Input.GetButtonDown("a"))
        {
            index = 0;
            if (item[index] == null)
            {
                return;
            }
            else if (item[index].stackable == true && item[index].quantity >= 1)
            {
                item[index].quantity -= 1;
                texts[index].text = item[index].quantity.ToString();
            }
            if (item[index] != null)
            {
                switch (item[index].itemType)
                {
                    case Item.ItemType.HEALTHY:
                        print("sssssssss");
                        player.adjusthealthy(item[index].addquanity);
                        break;
                    case Item.ItemType.MP:
                        print("sssssssss");
                        player.adjustmp(item[index].addquanity);
                        break;
                }
            }
            else
            {
                return;
            }
            if (item[index].quantity <= 0)
            {
                texts[index].text = "00";
                //texts[index].text = item[index].quantity.ToString();
                itemimage[index].sprite = null;
                itemimage[index].enabled = false;
                item[index] = null;
            }
           

        }
        if (Input.GetButtonDown("s"))
        {
            index = 1;
            if (item[index] == null)
            {
                return;
            }
            else if (item[index].stackable == true && item[index].quantity >= 1)
            {
                item[index].quantity -= 1;
                texts[index].text = item[index].quantity.ToString();
            }
            if (item[index] != null)
            {
                switch (item[index].itemType)
                {
                    case Item.ItemType.HEALTHY:
                        player.adjusthealthy(item[index].addquanity);
                        break;
                    case Item.ItemType.MP:
                        player.adjustmp(item[index].addquanity);
                        break;
                }
            }
            else
            {
                return;
            }
            if (item[index].quantity <= 0)
            {
                texts[index].text = "00";
               // texts[index].text = item[index].quantity.ToString();
                itemimage[index].sprite = null;
                itemimage[index].enabled = false;
                item[index] = null;
            }
           

        }
        if (Input.GetButtonDown("d"))
        {
            index = 2;
            if (item[index] == null)
            {
                return;
            }
            else if (item[index].stackable == true && item[index].quantity >= 1)
            {
                item[index].quantity -= 1;
                texts[index].text = item[index].quantity.ToString();
            }
            if (item[index] != null)
            {
                switch (item[index].itemType)
                {
                    case Item.ItemType.HEALTHY:
                        player.adjusthealthy(item[index].addquanity);
                        break;
                    case Item.ItemType.MP:
                        player.adjustmp(item[index].addquanity);
                        break;
                }
            }
            else
            {
                return;
            }
            if (item[index].quantity <= 0)
            {
                texts[index].text = "00";
                //texts[index].text = item[index].quantity.ToString();
                itemimage[index].sprite = null;
                itemimage[index].enabled = false;
                item[index] = null;
            }
           

        }
        if (Input.GetButtonDown("f"))
        {
            index = 3;
            if (item[index] == null)
            {
                return;
            }
            else if (item[index].stackable == true && item[index].quantity >= 1)
            {
                item[index].quantity -= 1;
                texts[index].text = item[index].quantity.ToString();
            }
            if (item[index] != null)
            {
                switch (item[index].itemType)
                {
                    case Item.ItemType.HEALTHY:
                        player.adjusthealthy(item[index].addquanity);
                        break;
                    case Item.ItemType.MP:
                        player.adjustmp(item[index].addquanity);
                        break;
                }
            }
            else
            {
                return;
            }
            if (item[index].quantity <= 0)
            {
                texts[index].text = "00";
               // texts[index].text = item[index].quantity.ToString();
                itemimage[index].sprite = null;
                itemimage[index].enabled = false;
                item[index] = null;
            }

        }
        if (Input.GetButtonDown("g"))
        {
            index = 4;
            if (item[index] == null)
            {
                return;
            }
            else if (item[index].stackable == true && item[index].quantity >= 1)
            {
                item[index].quantity -= 1;
                texts[index].text = item[index].quantity.ToString();
            }
            if (item[index] != null)
            {
                switch (item[index].itemType)
                {
                    case Item.ItemType.HEALTHY:
                        player.adjusthealthy(item[index].addquanity);
                        break;
                    case Item.ItemType.MP:
                        player.adjustmp(item[index].addquanity);
                        break;
                }
            }
            else
            {
                return;
            }
            if (item[index].quantity <= 0)
            {
                texts[index].text = "00";
                //texts[index].text = item[index].quantity.ToString();
                itemimage[index].sprite = null;
                itemimage[index].enabled = false;
                item[index] = null;
            }
            



        }
    }
}