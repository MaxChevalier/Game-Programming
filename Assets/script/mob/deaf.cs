using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class deaf : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySound());
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NavMeshAgent>().remainingDistance <= GetComponent<NavMeshAgent>().stoppingDistance && !GetComponent<NavMeshAgent>().pathPending) GetComponent<Animator>().SetBool("isRuning", false);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SoundCreator>() != null && other.gameObject.GetComponent<SoundCreator>().isPlaying)
        {
            GetComponent<NavMeshAgent>().SetDestination(other.gameObject.transform.position);
            GetComponent<Animator>().SetBool("isRuning", true);
            if (other.gameObject.transform.position.x < transform.position.x) GetComponent<SpriteRenderer>().flipX = true;
            else GetComponent<SpriteRenderer>().flipX = false;
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
