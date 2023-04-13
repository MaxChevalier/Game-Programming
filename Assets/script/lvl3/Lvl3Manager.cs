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
            firstMob.GetComponent<deaf>().enabled = true;
            firstMob.tag = "Mob";
        }
    }
}
