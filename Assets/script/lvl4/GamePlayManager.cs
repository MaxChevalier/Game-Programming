using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public bool haveJerryCan = false;
    public GetLvlItem getLvlItem;


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
        transform.GetChild(0).GetComponent<ElevatorZone>().OnInteract();
        transform.GetChild(1).GetComponent<GeneratorZone>().OnInteract();
        getLvlItem.OnInteract();
    }
}
