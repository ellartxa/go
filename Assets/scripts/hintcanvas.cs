using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintcanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hintprofab;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            hintprofab.SetActive(true);
            hintprofab.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") != false ) 
        {
            hintprofab.SetActive(false);
            hintprofab.GetComponent<Canvas>().enabled = false;
        }
    }
}
