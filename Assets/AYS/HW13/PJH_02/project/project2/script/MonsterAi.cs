using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    [Header("Patrolling Settings")]
    public Transform[] patrolPoints; // 순찰 경로 포인트
    private int currentPatrolIndex = 0;

    [Header("Detection Settings")]
    public Transform playerCamera; // 플레이어 카메라
    public float viewDistance = 15f; // 감지 거리
    public float viewAngle = 60f; // 감지 각도

    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent == null || animator == null)
        {
            Debug.LogError("NavMeshAgent 또는 Animator가 연결되지 않았습니다!");
        }

        if (playerCamera == null)
        {
            Debug.LogError("Player Camera가 설정되지 않았습니다!");
        }

        MoveToNextPatrolPoint();
    }

    void Update()
    {
        if (playerCamera != null && CanSeePlayer())
        {
            ChasePlayer();
        }
        else
        {
            if (isChasing)
            {
                StopChasing();
            }

            // 목적지에 도달했는지 확인
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !isChasing)
            {
                MoveToNextPatrolPoint();
            }
        }
    }

    void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            agent.destination = patrolPoints[currentPatrolIndex].position;
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length; // 순환적으로 이동
        }
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = playerCamera.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > viewDistance)
            return false;

        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer > viewAngle / 2f)
            return false;

        if (Physics.Raycast(transform.position, directionToPlayer.normalized, out RaycastHit hit, viewDistance))
        {
            if (hit.transform == playerCamera)
                return true;
        }

        return false;
    }

    void ChasePlayer()
    {
        isChasing = true;
        agent.SetDestination(playerCamera.position);
    }

    void StopChasing()
    {
        isChasing = false;
        MoveToNextPatrolPoint();
    }
}
