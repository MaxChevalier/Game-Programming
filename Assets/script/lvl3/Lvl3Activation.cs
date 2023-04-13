using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3Activation : MonoBehaviour
{
    public GameObject lvl3Manager;
    public GameObject hole;
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
            lvl3Manager.GetComponent<Lvl3Manager>().SpawnMobs();
            hole.SetActive(true);
            Destroy(gameObject);
        }
    }
}
