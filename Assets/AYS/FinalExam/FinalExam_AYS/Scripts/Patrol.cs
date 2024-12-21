using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform pointA; // 첫 번째 목표 지점
    public Transform pointB; // 두 번째 목표 지점

    private NavMeshAgent agent; // NavMeshAgent 참조
    private Transform currentTarget; // 현재 목표 지점

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // 초기 목표 지점 설정
        currentTarget = pointA;
        agent.SetDestination(currentTarget.position);
    }

    void Update()
    {
        // 목표 지점에 도달했는지 확인
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // 목표 지점 전환
            currentTarget = (currentTarget == pointA) ? pointB : pointA;

            // 새 목표 지점 설정
            agent.SetDestination(currentTarget.position);
        }

        // 이동 방향을 바라보게 회전 조정
        if (agent.velocity.sqrMagnitude > 0.1f) // 움직이는 중인지 확인
        {
            Vector3 direction = agent.velocity.normalized; // 이동 방향
            Quaternion targetRotation = Quaternion.LookRotation(direction); // 목표 회전값
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f); // 부드럽게 회전
        }
    }
}
