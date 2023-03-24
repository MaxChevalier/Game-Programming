using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class baby : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
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
        }
    }
}
