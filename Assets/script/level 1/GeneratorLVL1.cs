using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneratorLVL1 : MonoBehaviour
{
    public bool isInRange;
    public bool LockKey = false;
    public GameObject GeneratorUI;
    private GameObject InteractUI;
    private AudioSource audioSource;

    void Start()
    {
        InteractUI = GameObject.Find("GameManager").GetComponent<GameManager>().InteractUI;
        audioSource = transform.parent.GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    public void OnInteract(){
        if (isInRange){
            if (!LockKey){
                if (transform.parent.GetComponent<GeneretorsManagerLvl1>().OneActive){
                    StopAllCoroutines();
                    StartCoroutine(DisplayMessage("You can only turn on one generator !", Color.red));
                    audioSource.Play();
                }
                else {
                    GetComponent<AudioSource>().Play();
                    LockKey = true;
                    StopAllCoroutines();
                    StartCoroutine(DisplayMessage("This generator is on", Color.green));
                    transform.parent.GetComponent<GeneretorsManagerLvl1>().OneActive = true;
                    transform.GetChild(0).GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.green;
                }
            }
            else {
                GetComponent<AudioSource>().Stop();
                LockKey = false;
                StopAllCoroutines();
                StartCoroutine(DisplayMessage("This generator is off", Color.red));
                transform.parent.GetComponent<GeneretorsManagerLvl1>().OneActive = false;
                transform.GetChild(0).GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.red;
            }
        }
    }

    private IEnumerator DisplayMessage(string message, Color color){
        GeneratorUI.GetComponent<TextMeshProUGUI>().text = message;
        GeneratorUI.GetComponent<TextMeshProUGUI>().color = color;
        GeneratorUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        GeneratorUI.SetActive(false);
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
