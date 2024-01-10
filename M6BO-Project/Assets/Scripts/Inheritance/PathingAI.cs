using UnityEngine;
using UnityEngine.AI;

public class PathingAI : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    public EntityStats stats;
    public Transform model;
    public bool awoken;
    public EnemyFOV fov;
    public float aggroTimer;
    public virtual void Start()
    {
        GetAll();
    }

    public virtual void Update()
    {
        CheckForPlayer();
        HandleRotation();
        CheckAggroTimer();
    }

    public virtual void GetAll()
    {
        model = transform.GetChild(0);
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<EntityStats>();
        fov = GetComponent<EnemyFOV>();
        agent.isStopped = true;
        agent.updateRotation = false;
        agent.speed = stats.movementSpeed;
    }

    public virtual void CheckForPlayer()
    {
        Transform target = fov.FindVisibleTargets();
        if (target != null && agent.enabled)
        {
            Vector3 targetPos = target.position;
            if (!awoken)
            {
                agent.isStopped = false;
                awoken = true;
            }
            agent.SetDestination(targetPos);
            fov.viewAngle = 360;
            aggroTimer = 20;
        }
    }

    public virtual void HandleRotation()
    {
        if (agent.enabled)
        {
            GetComponent<Rigidbody>().freezeRotation = false;
            model.rotation = UpdateDirection(agent.steeringTarget);
        }
        else GetComponent<Rigidbody>().freezeRotation = true;
    }

    public void CheckAggroTimer()
    {
        aggroTimer -= Time.deltaTime;
        if (aggroTimer <= 0)
        {
            fov.viewAngle = 190;
        }
    }
    public Quaternion UpdateDirection(Vector3 target)
    {
        Vector3 lookDir = target - transform.position;
        lookDir = new Vector3(lookDir.x, 0, lookDir.z);
        if (lookDir.magnitude <= 0.1f && lookDir.magnitude >= -0.1f) return Quaternion.identity;
        Quaternion lookRot = Quaternion.LookRotation(lookDir);
        return Quaternion.Lerp(model.rotation, lookRot, Time.deltaTime * stats.rotSpeed);
    }
}
