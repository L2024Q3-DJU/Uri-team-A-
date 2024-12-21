using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도
    public float idleTime = 3f; // Idle 상태 지속 시간
    public float playerDetectionRange = 5f; // 플레이어 탐지 거리
    public LayerMask obstacleLayer; // 충돌 체크를 위한 레이어

    private Animator animator;
    private Transform player;

    private string currentState = "Idle";
    private float stateTimer = 0f;

    private Vector3 lastPosition; // 이전 좌표
    private float stuckTimer = 0f; // 멈춘 시간

    void Start()
    {
        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on NPC!");
        }

        // Player 태그를 가진 객체 찾기
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        lastPosition = transform.position; // 초기 위치 저장
    }

    void Update()
    {
        // 플레이어 감지
        if (player != null && Vector3.Distance(transform.position, player.position) <= playerDetectionRange)
        {
            SwitchState("Idle");
            return;
        }

        // 상태 처리
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0f)
        {
            DecideNextState();
        }

        // NPC 이동
        if (currentState == "Running")
        {
            Move();
        }

        // 멈춘 상태 체크
        CheckStuck();
    }

    private void CheckStuck()
    {
        // NPC가 이동 중이지만 1초 이상 좌표값이 변하지 않으면 방향 변경
        if (currentState == "Running")
        {
            if (Vector3.Distance(transform.position, lastPosition) < 0.1f)
            {
                stuckTimer += Time.deltaTime;
                if (stuckTimer >= 1f) // 1초 동안 멈춰 있으면
                {
                    ChangeDirection();
                    stuckTimer = 0f; // 멈춘 시간 초기화
                }
            }
            else
            {
                stuckTimer = 0f; // 움직임 감지 시 멈춘 시간 초기화
            }
            lastPosition = transform.position; // 현재 위치 저장
        }
    }

    private void Move()
    {
        // NPC 이동
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        // 새로운 랜덤 방향 설정
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, randomAngle, 0);
        Debug.Log("NPC stuck, changing direction.");
    }

    private void DecideNextState()
    {
        // 상태 전환 결정 (Idle ↔ Running)
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
                stateTimer = Random.Range(3f, 5f); // 달리는 시간 랜덤
                break;
        }
    }
}
