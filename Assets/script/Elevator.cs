using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject InteractUI;
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
         OpenElevator();
        }
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
