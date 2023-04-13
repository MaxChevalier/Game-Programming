using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLVL1 : MonoBehaviour
{
    public Elevator elevator;
    public Elevator elevator2;
    public Elevator elevator3;
    public GeneretorsManager generator;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = transform.GetChild(4).GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnInteract()
    {
        elevator.OnInteract();
        elevator2.OnInteract();
        elevator3.OnInteract();
        generator.OnInteract();
    }
}
