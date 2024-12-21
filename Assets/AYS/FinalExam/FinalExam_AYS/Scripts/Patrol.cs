using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform pointA; // ù ��° ��ǥ ����
    public Transform pointB; // �� ��° ��ǥ ����

    private NavMeshAgent agent; // NavMeshAgent ����
    private Transform currentTarget; // ���� ��ǥ ����

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // �ʱ� ��ǥ ���� ����
        currentTarget = pointA;
        agent.SetDestination(currentTarget.position);
    }

    void Update()
    {
        // ��ǥ ������ �����ߴ��� Ȯ��
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // ��ǥ ���� ��ȯ
            currentTarget = (currentTarget == pointA) ? pointB : pointA;

            // �� ��ǥ ���� ����
            agent.SetDestination(currentTarget.position);
        }

        // �̵� ������ �ٶ󺸰� ȸ�� ����
        if (agent.velocity.sqrMagnitude > 0.1f) // �����̴� ������ Ȯ��
        {
            Vector3 direction = agent.velocity.normalized; // �̵� ����
            Quaternion targetRotation = Quaternion.LookRotation(direction); // ��ǥ ȸ����
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f); // �ε巴�� ȸ��
        }
    }
}
