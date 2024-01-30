using UnityEngine;
using UnityEngine.AI;

public class EnemyParentAnimScript : MonoBehaviour
{
    // this is painful but the only way I found to have the enemy rotate towards the target
    private NavMeshAgent _agent;
    private BasicEnemyLunge _lungeScript;
    void Start()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
        _lungeScript = GetComponentInParent<BasicEnemyLunge>();
    }

    public void StopAgent()
    {
        _agent.isStopped = true;
    }

    public void StartAgent()
    {
        _agent.isStopped = false;
    }

    public void StartLunge()
    {
        Vector3 direction = (_agent.steeringTarget - transform.position).normalized;
        _lungeScript.GetLungeDirection(direction);

        _lungeScript.isLunging = true;
    }

    public void EndLunge()
    {
        _lungeScript.isLunging = false;
    }

    public void InitDeath()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponentInParent<NavMeshAgent>().isStopped = true;
        GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        transform.GetChild(3).gameObject.SetActive(false);
    }

}
