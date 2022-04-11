using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleshoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject battletype;
    static List<GameObject> battles;
    public int battlenum = 5;
    private void Awake()
    {
        //初始化链表
            battles = new List<GameObject>();
        
        //向链表中加入数据
        for (int i = 0; i < battlenum; i++)
        {
            GameObject objects = Instantiate(battletype);
            objects.SetActive(false);
            battles.Add(objects);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firebattle();
        }
    }
    private void firebattle()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - new Vector2(transform.position.x, transform.position.y);
        float angle =
        Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        spawnbattle(transform.position, rotation);
    }
    GameObject spawnbattle(Vector3 position, Quaternion rotation)
    {
        foreach (GameObject battle in battles)
        {
            if (battle.activeSelf == false)
            {
                battle.transform.position = position;
                battle.transform.rotation = rotation;
                battle.SetActive(true);
                return battle;
            }
        }
        return null;
    }
}
