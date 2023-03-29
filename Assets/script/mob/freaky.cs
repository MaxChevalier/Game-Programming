using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class freaky : MonoBehaviour
{

    public AudioClip[] audioClips;
    private bool isPlayerInRange = false;
    
    Vector3 refPos;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NewPositionCoroutine());
        if (audioClips.Length > 0)
        {
            audioSource = GetComponent<AudioSource>();
            StartCoroutine(FreakyPlaySound());
        }
        refPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewPosition()
    {
        Vector3 rdmVector = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        Vector3 CurrentPosition = transform.position;
        float maxDistance = 10f;
        // if 
        // SetTragetPosition(targetPosition);
    }

    private void SetTragetPosition(Vector3 position)
    {
        GetComponent<NavMeshAgent>().SetDestination(position);
    }

    IEnumerator NewPositionCoroutine()
    {
        while (true)
        {
            if (! isPlayerInRange)
            {
                NewPosition();
            }
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator FreakyPlaySound()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 10f));
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.Stop();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetTragetPosition(other.gameObject.transform.position);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
            SetTragetPosition(transform.position);
        }
    }
}
