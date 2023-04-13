using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ElevatorZone : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GeneratorZone GeneratorZone;
    public GameObject InteractUI;
    SayText sayText;

    bool isInRange;

    // Start is called before the first frame update
    void Start()
    {
        sayText = GameObject.Find("TextSay").GetComponent<SayText>();
        isInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            isInRange = true;
            InteractUI.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            isInRange = false;
            InteractUI.SetActive(false);
        }
    }

    public void OnInteract()
    {
        if (isInRange)
        {
            if (GeneratorZone.GeneratorTurnOn == GeneratorZone.TotGenerator)
            {
                SceneManager.LoadScene("GameEnd");
            }
            else{
                sayText.ChangeText("No Power.\nI can't use the elevator.");
                StartCoroutine(sayText.ShowText());
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
    
}
