using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class freaky : MonoBehaviour
{

    public AudioClip[] audioClips;
    private bool isPlayerInRange = false;
    private Animator animator;
    
    Vector3 refPos;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        if (GetComponent<NavMeshAgent>().remainingDistance <= GetComponent<NavMeshAgent>().stoppingDistance && !GetComponent<NavMeshAgent>().pathPending)
        {
            animator.SetInteger("movement", 0);
        }
    }

    void NewPosition()
    {
        Vector3 rdmVector = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
        Vector3 CurrentPosition = transform.position;
        float maxDistance = 10f;
        if (Vector3.Distance(CurrentPosition, refPos) > maxDistance)
        {
            SetTragetPosition(refPos);
        }
        else if (Vector3.Distance(CurrentPosition + rdmVector, refPos) < maxDistance)
        {
            SetTragetPosition(CurrentPosition + rdmVector);
            if (rdmVector.x<0) GetComponent<SpriteRenderer>().flipX = true;
            else GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            SetTragetPosition(CurrentPosition - rdmVector);
        }
        animator.SetInteger("movement", 1);
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
            yield return new WaitForSeconds(3f);
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
            GetComponent<NavMeshAgent>().speed = 3f;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetTragetPosition(other.gameObject.transform.position);
            animator.SetInteger("movement", 2);
            if (other.gameObject.transform.position.x < transform.position.x) GetComponent<SpriteRenderer>().flipX = true;
            else GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
            SetTragetPosition(transform.position);
            animator.SetInteger("movement", 0);
            GetComponent<NavMeshAgent>().speed = 2f;
        }
    }
}
