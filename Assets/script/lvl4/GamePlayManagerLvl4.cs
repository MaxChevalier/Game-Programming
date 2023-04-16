using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManagerLvl4 : MonoBehaviour
{
    public bool haveJerryCan = false;
    public GetLvl4Item getLvlItem;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract()
    {
        transform.GetChild(0).GetComponent<ElevatorZoneLvl4>().OnInteract();
        transform.GetChild(1).GetComponent<GeneratorZoneLvl4>().OnInteract();
        getLvlItem.OnInteract();
    }
}
