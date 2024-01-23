using UnityEngine;
using UnityEngine.AI;

public class PathingAI : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    public EntityStats entityStats;
    public Transform model;
    public bool awoken;
    public EnemyFOV enemyfov;
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
        entityStats = GetComponent<EntityStats>();
        enemyfov = GetComponent<EnemyFOV>();
        agent.isStopped = true;
        agent.updateRotation = false;
        agent.speed = entityStats.movementSpeed;
    }

    public virtual void CheckForPlayer()
    {
        Transform target = enemyfov.FindVisibleTargets();
        if (target != null) TryWakeUp();
        if (target != null && !agent.isStopped)
        {
            Vector3 targetPos = target.position;
            TryWakeUp();
            agent.SetDestination(targetPos);
            enemyfov.viewAngle = 360;
            aggroTimer = 20;
        }
    }

    public virtual void HandleRotation()
    {
        if (!agent.isStopped)
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
            enemyfov.viewAngle = 190;
        }
    }

    public Quaternion UpdateDirection(Vector3 target)
    {
        Vector3 lookDir = target - transform.position;
        lookDir = new Vector3(lookDir.x, 0, lookDir.z);
        if (lookDir.magnitude <= 0.1f && lookDir.magnitude >= -0.1f) return Quaternion.identity;
        Quaternion lookRot = Quaternion.LookRotation(lookDir);
        return Quaternion.Lerp(model.rotation, lookRot, Time.deltaTime * entityStats.rotSpeed);
    }

    public void TryWakeUp()
    {
        if (!awoken)
        {
            agent.isStopped = false;
            awoken = true;
            enemyfov.viewAngle = 360;
            aggroTimer = 20;
        }
    }
}
