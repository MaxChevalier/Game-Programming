using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class freaky : MonoBehaviour
{

    private bool isPlayerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NewPositionCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewPosition()
    {
        Vector3 targetPosition = new Vector3(Random.Range(-2, 2)+transform.position.x, Random.Range(-2, 2)+transform.position.y, transform.position.z);
        SetTragetPosition(targetPosition);
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
        }
    }
}
