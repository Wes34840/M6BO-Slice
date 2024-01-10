using UnityEngine;
using UnityEngine.AI;

public class EnemyParentAnimScript : MonoBehaviour
{
    // this is painful but the only way I found to have the enemy rotate towards the target
    private NavMeshAgent agent;
    private BasicEnemyLunge lungeScript;
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        lungeScript = GetComponentInParent<BasicEnemyLunge>();
    }

    public void StopAgent()
    {
        agent.enabled = false;
    }

    public void StartAgent()
    {
        agent.enabled = true;
    }

    public void StartLunge()
    {
        Vector3 dir = (agent.steeringTarget - transform.position).normalized;
        lungeScript.GetLungeDirection(dir);

        lungeScript.isLunging = true;
    }

    public void EndLunge()
    {
        lungeScript.isLunging = false;
    }

}
