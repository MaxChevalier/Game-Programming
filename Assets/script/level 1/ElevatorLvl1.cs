using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorLvl1 : MonoBehaviour
{
    public GameObject InteractUI;
    public GameObject ElevatorLockUI;
    public GeneretorsManagerLvl1 generator;
    public int ID;
    public GameObject mob;

    private bool isInRange;
    private Animator animator;
    private AudioSource audioSource;
    private Collider2D collider2D;


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
    }

    IEnumerator OpenElevator()
    {
        Debug.Log("Le script OpenElevator a démarré !");
        animator.SetTrigger("OpenElevator");
        BoxCollider2D[] boxCollider2Ds = GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D boxCollider2D in boxCollider2Ds)
        {
            if (!boxCollider2D.isTrigger)
            {
                boxCollider2D.enabled = false;
            }
        }
        if (ID == 1)
        {
        }
        else if (ID == 0)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("LVL3");
        }
        else if (ID == 2)
        {
            mob.SetActive(true);
        }
    }

    public void OnInteract()
    {
        if (isInRange)
        {
            if (!generator.generatorsList[ID].LockKey)
            {
                StartCoroutine(ElevatorLockMessage());
                audioSource.Play();

            }
            else
            {
                StartCoroutine(OpenElevator());
            }
        }
    }

    private IEnumerator ElevatorLockMessage()
    {
        ElevatorLockUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        ElevatorLockUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractUI.SetActive(true);
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractUI.SetActive(false);
            isInRange = false;
        }
    }
}
