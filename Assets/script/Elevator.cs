using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject InteractUI;
    public GameObject ElevatorLockUI;
    public GeneratorLVL1 generator;

    private bool isInRange;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    void OpenElevator(){
        Debug.Log("Le script OpenElevator a démarré !");
        animator.SetTrigger("OpenElevator");
    }

    public void OnInteract(){
        if (isInRange){
        if (!generator.LockKey){
            StartCoroutine(ElevatorLockMessage());
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
