using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLvl4 : MonoBehaviour
{
    private GamePlayManager lvlActionManager;
    // Start is called before the first frame update
    void Start()
    {
        lvlActionManager = GameObject.Find("lvlActionManager").GetComponent<GamePlayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnInteract()
    {    
        lvlActionManager.OnInteract();
    }
}
