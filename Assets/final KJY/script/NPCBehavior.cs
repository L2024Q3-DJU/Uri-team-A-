using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public float moveSpeed = 3f; // �̵� �ӵ�
    public float idleTime = 3f; // Idle ���� ���� �ð�
    public float playerDetectionRange = 5f; // �÷��̾� Ž�� �Ÿ�
    public LayerMask obstacleLayer; // �浹 üũ�� ���� ���̾�

    private Animator animator;
    private Transform player;

    private string currentState = "Idle";
    private float stateTimer = 0f;

    private Vector3 lastPosition; // ���� ��ǥ
    private float stuckTimer = 0f; // ���� �ð�

    void Start()
    {
        // Animator ������Ʈ ��������
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on NPC!");
        }

        // Player �±׸� ���� ��ü ã��
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        lastPosition = transform.position; // �ʱ� ��ġ ����
    }

    void Update()
    {
        // �÷��̾� ����
        if (player != null && Vector3.Distance(transform.position, player.position) <= playerDetectionRange)
        {
            SwitchState("Idle");
            return;
        }

        // ���� ó��
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0f)
        {
            DecideNextState();
        }

        // NPC �̵�
        if (currentState == "Running")
        {
            Move();
        }

        // ���� ���� üũ
        CheckStuck();
    }

    private void CheckStuck()
    {
        // NPC�� �̵� �������� 1�� �̻� ��ǥ���� ������ ������ ���� ����
        if (currentState == "Running")
        {
            if (Vector3.Distance(transform.position, lastPosition) < 0.1f)
            {
                stuckTimer += Time.deltaTime;
                if (stuckTimer >= 1f) // 1�� ���� ���� ������
                {
                    ChangeDirection();
                    stuckTimer = 0f; // ���� �ð� �ʱ�ȭ
                }
            }
            else
            {
                stuckTimer = 0f; // ������ ���� �� ���� �ð� �ʱ�ȭ
            }
            lastPosition = transform.position; // ���� ��ġ ����
        }
    }

    private void Move()
    {
        // NPC �̵�
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        // ���ο� ���� ���� ����
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, randomAngle, 0);
        Debug.Log("NPC stuck, changing direction.");
    }

    private void DecideNextState()
    {
        // ���� ��ȯ ���� (Idle �� Running)
        if (currentState == "Idle")
        {
            SwitchState("Running");
        }
        else
        {
            SwitchState("Idle");
        }
    }

    private void SwitchState(string newState)
    {
        currentState = newState;

        switch (newState)
        {
            case "Idle":
                animator.SetBool("isRunning", false);
                stateTimer = idleTime;
                break;

            case "Running":
                animator.SetBool("isRunning", true);
                stateTimer = Random.Range(3f, 5f); // �޸��� �ð� ����
                break;
        }
    }
}
