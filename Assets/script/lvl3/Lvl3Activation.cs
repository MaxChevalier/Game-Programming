using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lvl3Activation : MonoBehaviour
{
    public GameObject lvl3Manager;
    public GameObject hole;
    public SayText text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.ChangeText("What the hell is that?\nI ... I have to get out of here!");
            StartCoroutine(text.ShowText());
            lvl3Manager.GetComponent<Lvl3Manager>().SpawnMobs();
            hole.SetActive(true);
        }
    }
}
