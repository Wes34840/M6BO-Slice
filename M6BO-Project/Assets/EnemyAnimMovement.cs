using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimMovement : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponentInParent<NavMeshAgent>();
    }

    void Update()
    {
        _anim.SetBool("Walking", !_agent.isStopped);
    }
}
