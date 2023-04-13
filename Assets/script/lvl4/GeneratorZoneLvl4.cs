using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorZoneLvl4 : MonoBehaviour
{
    public int GeneratorTurnOn = 0;
    public int TotGenerator = 6;
    public GameObject InteractUI;
    public AudioClip[] audioClip;
    public AudioSource audioSourcePlayer;
    AudioSource audioSource;

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

    public void OnInteract()
    {
        if (isInRange)
        {
            if (transform.parent.GetComponent<GamePlayManagerLvl4>().haveJerryCan)
            {
                GeneratorTurnOn++;
                transform.parent.GetComponent<GamePlayManagerLvl4>().haveJerryCan = false;
                sayText.ChangeText("Generator Turn On: " + GeneratorTurnOn + "/" + TotGenerator);
                audioSource = transform.GetChild(GeneratorTurnOn - 1).GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioClip[0]);
                StartCoroutine(sayText.ShowText());
                if (GeneratorTurnOn == TotGenerator)
                {
                    for (int i = 0; i < TotGenerator; i++)
                    {
                        audioSource = transform.GetChild(i).GetComponent<AudioSource>();
                        audioSource.clip = audioClip[1];
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                }
            }
            else
            {
                if (GeneratorTurnOn == TotGenerator)
                {
                    sayText.ChangeText("All Generator is Turn On.\nI can use the elevator now.");
                    StartCoroutine(sayText.ShowText());
                }
                else
                {
                    sayText.ChangeText("I need a Jerry Can to fill the generator.");
                    StartCoroutine(sayText.ShowText());
                    audioSourcePlayer.PlayOneShot(audioClip[2]);
                }
            }
        }
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
}
