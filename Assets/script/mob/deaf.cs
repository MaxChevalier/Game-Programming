using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class deaf : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SoundCreator>() != null && other.gameObject.GetComponent<SoundCreator>().isPlaying)
        {
            GetComponent<NavMeshAgent>().SetDestination(other.gameObject.transform.position);
        }
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        while (true){
            audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length+Random.Range(0f, 3f));
        }
    }
    
}
