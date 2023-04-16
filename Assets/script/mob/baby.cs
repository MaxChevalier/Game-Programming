using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class baby : MonoBehaviour
{

    AudioSource audioSource;
    // Start is called before the first frame update
    public void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(BabyPlaySound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<NavMeshAgent>().SetDestination(other.gameObject.transform.position);
            if (other.gameObject.transform.position.x > transform.position.x) GetComponent<SpriteRenderer>().flipX = true;
            else GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    IEnumerator BabyPlaySound()
    {
        while (true){
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.Stop();
        }
    }
}
