using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class charger : MonoBehaviour
{
    public int direction = 0;
    
    private Vector3 OwnPosition;
    private Vector3 Target;

    Animator animator;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        OwnPosition = transform.position;
        animator = GetComponent<Animator>();
        animator.SetInteger("directional", direction);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.velocity.magnitude > 0)
        {
            animator.SetBool("runing", true);
        }
        else
        {
            animator.SetBool("runing", false);
        }
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
        navMeshAgent.SetDestination(Target);
        yield return new WaitForSeconds(2f);
        navMeshAgent.SetDestination(OwnPosition);
    }
}
