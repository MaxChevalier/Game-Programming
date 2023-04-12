using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLVL1 : MonoBehaviour
{
    public Elevator elevator;
    public GeneratorLVL1 generator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnInteract()
    {
        elevator.OnInteract();
        generator.OnInteract();
    }
}
