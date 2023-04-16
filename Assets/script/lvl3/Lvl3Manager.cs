using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3Manager : MonoBehaviour
{
    public GameObject firstMob;
    GameObject[] mobs;
    // Start is called before the first frame update
    void Start()
    {
        mobs = GameObject.FindGameObjectsWithTag("Mob");
        foreach (GameObject mob in mobs)
        {
            mob.SetActive(false);
        }
        firstMob.GetComponent<deaf>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMobs()
    {
        foreach (GameObject mob in mobs)
        {
            mob.SetActive(true);
            if (mob.GetComponent<deaf>()) mob.GetComponent<deaf>().Start();
            else if (mob.GetComponent<freaky>()) mob.GetComponent<freaky>().Start();
            else if (mob.GetComponent<baby>()) mob.GetComponent<baby>().Start();
        }
        firstMob.GetComponent<deaf>().enabled = true;
        firstMob.tag = "Mob";
        firstMob.GetComponent<CircleCollider2D>().enabled = true;
    }
}
