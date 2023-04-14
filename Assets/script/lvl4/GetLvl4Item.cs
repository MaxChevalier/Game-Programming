using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLvl4Item : MonoBehaviour
{
    private GameObject InteractUI;
    public GamePlayManagerLvl4 gamePlayManager;
    public AudioClip[] audioClip;
    AudioSource audioSource;
    private bool isInRange;
    private bool destroy = false;
    SayText sayText;

    void Start()
    {
        sayText = GameObject.Find("TextSay").GetComponent<SayText>();
        audioSource = transform.parent.GetComponent<AudioSource>();
        InteractUI = GameObject.Find("GameManager").GetComponent<GameManager>().InteractUI;
        InteractUI.SetActive(false);
    }

    void Update()
    {
    }

    public void OnInteract(){
        if (isInRange){
            if (gamePlayManager.haveJerryCan)
            {
                sayText.ChangeText("I already have a Jerry Can.");
                StartCoroutine(sayText.ShowText());
            }
            else
            {
                audioSource.PlayOneShot(audioClip[0]);
                gamePlayManager.haveJerryCan = true;
                destroy = true;
                transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(0.001f,0.001f);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("lvlItem")){
            InteractUI.SetActive(true);
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("lvlItem")){
            InteractUI.SetActive(false);
            isInRange = false;
        }
    }
    void OnTriggerStay2D(Collider2D other) {
    if (other.CompareTag("lvlItem") && destroy) {
        Destroy(other.gameObject);
        destroy = false;
    }
}
}
