using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private GameObject InteractUI;
    private bool isInRange;
    private bool destroy = false;
    AudioSource audioSource;

    void Start()
    {
        InteractUI = GameObject.Find("GameManager").GetComponent<GameManager>().InteractUI;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    public void OnInteract(){
        if (isInRange){
            Inventory.instance.AddItems(1);
            destroy = true;
            //Destroy(GameObject.FindWithTag("Item"));
            transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(0.001f,0.001f);
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
    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Item") && destroy) {
            Destroy(other.gameObject);
            audioSource.Play();
            destroy = false;
        }
    }
}
