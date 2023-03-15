using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class deaf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        UnityEngine.Debug.Log("e");
        if (other.gameObject.GetComponent<SoundCreator>() != null && other.gameObject.GetComponent<SoundCreator>().isPlaying)
        {
            GetComponent<NavMeshAgent>().SetDestination(other.gameObject.transform.position);
        }
    }
    
}
