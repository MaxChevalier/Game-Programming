using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLvl4 : MonoBehaviour
{
    public AudioClip audioClipStartLvl;
    private GamePlayManager lvlActionManager;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        lvlActionManager = GameObject.Find("lvlActionManager").GetComponent<GamePlayManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClipStartLvl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnInteract()
    {    
        lvlActionManager.OnInteract();
    }
}
