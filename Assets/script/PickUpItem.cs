using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public GameObject InteractUI;
    private bool isInRange;
    void Awake()
    {

    }

    void Update()
    {
    }

    void OnInteract(){
        if (isInRange){
            Inventory.instance.AddItems(1);
            Destroy(GameObject.FindWithTag("Item"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Item")){
            InteractUI.SetActive(true);
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Item")){
            InteractUI.SetActive(false);
            isInRange = false;
        }
    }
}
