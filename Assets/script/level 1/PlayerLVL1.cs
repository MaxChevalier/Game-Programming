using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLVL1 : MonoBehaviour
{
    public ElevatorLvl1 elevator;
    public ElevatorLvl1 elevator2;
    public ElevatorLvl1 elevator3;
    public GeneretorsManagerLvl1 generator;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = transform.GetChild(4).GetComponent<AudioSource>();
        StartCoroutine(Intro());
    }
    IEnumerator Intro(){
        yield return new WaitForSeconds(0.5f);
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
