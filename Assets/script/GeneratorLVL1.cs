using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLVL1 : MonoBehaviour
{
    public bool isInRange;
    public bool LockKey = false;
    public GameObject GeneratorlockUI;
    public GameObject GeneratorUnlockUI;
    public GameObject GeneratorLimitUI;
    public GameObject InteractUI;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = transform.parent.GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    public void OnInteract(){
        if (isInRange){
            if (!LockKey){
                if (transform.parent.GetComponent<GeneretorsManager>().OneActive){
                    GeneratorUnlockUI.SetActive(false);
                    StartCoroutine(DisplayMessage(GeneratorLimitUI));
                    Debug.Log("vous ne pouvez pas activer 2 générateurs en même temps !");
                    audioSource.Play();
                }
                else {
                     LockKey = true;
                     GeneratorLimitUI.SetActive(false);
                     StartCoroutine(DisplayMessage(GeneratorUnlockUI));
                     transform.parent.GetComponent<GeneretorsManager>().OneActive = true;
                }
            }
            else {
                LockKey = false;
                StartCoroutine(DisplayMessage(GeneratorlockUI));
                transform.parent.GetComponent<GeneretorsManager>().OneActive = false;
            }
        }
    }

    private IEnumerator DisplayMessage(GameObject message){
        message.SetActive(true);
        yield return new WaitForSeconds(2f);
        message.SetActive(false);
    }

    // private IEnumerator GeneratorlockMessage(){
    //     GeneratorUnlockUI.SetActive(false);
    //     GeneratorlockUI.SetActive(true);
    //     yield return new WaitForSeconds(2f);
    //     GeneratorlockUI.SetActive(false);
    // }
    // private IEnumerator GeneratorUnlockMessage(){
    //     GeneratorlockUI.SetActive(false);
    //     GeneratorUnlockUI.SetActive(true);
    //     yield return new WaitForSeconds(2f);
    //     GeneratorUnlockUI.SetActive(false);
    // }

    // private IEnumerator GeneratorLimitMessage(){
    //     GeneratorLimitUI.SetActive(true);
    //     yield return new WaitForSeconds(2f);
    //     GeneratorLimitUI.SetActive(false);
    // }


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
