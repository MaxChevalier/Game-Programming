using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject InteractUI;
    public GameObject ElevatorLockUI;
    public GeneretorsManager generator;
    public int ID;

    private bool isInRange;
    private Animator animator;
    private AudioSource audioSource;
    private Collider2D collider2D;


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
    }

    void OpenElevator(){
        Debug.Log("Le script OpenElevator a démarré !");
        animator.SetTrigger("OpenElevator");
        if (ID == 1) {
             collider2D.enabled = false;
        }
    }

    public void OnInteract(){
        if (isInRange){
        if (!generator.generatorsList[ID].LockKey){
            StartCoroutine(ElevatorLockMessage());
            audioSource.Play();
            
        }
        else {
                OpenElevator();      
        }
        }
    }

    private IEnumerator ElevatorLockMessage(){
        ElevatorLockUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        ElevatorLockUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            InteractUI.SetActive(true);
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            InteractUI.SetActive(false);
            isInRange = false;
        }
    }
}
