using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;

    [Header("Normal Stats")]
    public float normalDetectionRange = 10f;
    public float normalSpeed = 2f;

    [Header("Aggressive Stats")]
    public float aggressiveDetectionRange = 20f;
    public float aggressiveSpeed = 4f;

    [Header("Attack")]
    public float attackRange = 2f;
    public int damage = 1;
    public float attackDelay = 1f;

    public GameManager gameManager;

    [Header("Patrol Auto")]
    public float patrolDistance = 5f;

    Vector3 patrolPointA;
    Vector3 patrolPointB;
    bool goingToA = true;

    float attackTimer;
    float pathUpdateTimer;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // titik patrol otomatis dari posisi spawn
        patrolPointA = transform.position + transform.forward * patrolDistance;
        patrolPointB = transform.position - transform.forward * patrolDistance;
    }

    void Update()
    {
        if (player == null) return;

        float currentRange = normalDetectionRange;
        float currentSpeed = normalSpeed;

        if (gameManager != null && gameManager.isAggressive)
        {
            currentRange = aggressiveDetectionRange;
            currentSpeed = aggressiveSpeed;
        }

        agent.speed = currentSpeed;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= currentRange)
        {
            if (distance > attackRange)
            {
                // 🧟 CHASE
                agent.isStopped = false;

                pathUpdateTimer += Time.deltaTime;
                if (pathUpdateTimer >= 0.2f)
                {
                    Vector3 targetPos = player.position;

                    targetPos += new Vector3(
                        Random.Range(-1.2f, 1.2f),
                        0,
                        Random.Range(-1.2f, 1.2f)
                    );

                    agent.SetDestination(targetPos);
                    pathUpdateTimer = 0f;
                }
            }
            else
            {
                // 🧟 ATTACK
                agent.isStopped = true;

                attackTimer += Time.deltaTime;
                if (attackTimer >= attackDelay)
                {
                    Attack();
                    attackTimer = 0f;
                }
            }
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        agent.isStopped = false;

        Vector3 target = goingToA ? patrolPointA : patrolPointB;
        agent.SetDestination(target);

        float distance = Vector3.Distance(transform.position, target);

        if (distance < 1f)
        {
            goingToA = !goingToA;
        }
    }

    void Attack()
    {
        PlayerHealth ph = player.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.TakeDamage(damage);
        }
    }
}