using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class charger : MonoBehaviour
{
    private Vector3 OwnPosition;
    private Vector3 Target;

    // Start is called before the first frame update
    void Start()
    {
        OwnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Target = collision.gameObject.transform.position;
            StartCoroutine(Chasse());
        }
    }

    private IEnumerator Chasse()
    {
        GetComponent<NavMeshAgent>().SetDestination(Target);
        yield return new WaitForSeconds(2f);
        GetComponent<NavMeshAgent>().SetDestination(OwnPosition);
    }
}
