using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{
    public GameObject hintprofab;
    public AudioClip audio4;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audio4 != null) 
            {
                audio.clip = audio4;
                audio.Play();
            }
            hintprofab.SetActive(true);
            hintprofab.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") != false)
        {
            hintprofab.SetActive(false);
            hintprofab.GetComponent<Canvas>().enabled = false;
        }
    }
}
