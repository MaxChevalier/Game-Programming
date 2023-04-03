using UnityEngine;
using UnityEngine.AI;
 
public class MoveeeAI : MonoBehaviour
{
public Transform target;
 
NavMeshAgent agent;
//
 
void Start()
{
agent = GetComponent<NavMeshAgent>();
agent.updateRotation = false;
agent.updateUpAxis = false;
}
 
private void OnTriggerEnter2D(Collider2D other)
{
if (other.tag == "Player")
{
agent.SetDestination(target.position);
}
}
 
private void OnTriggerStay2D(Collider2D other)
{
if (other.tag == "Player")
{
agent.SetDestination(target.position);
}
}
}