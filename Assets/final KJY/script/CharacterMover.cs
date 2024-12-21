using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도
    private Animator animator;
    private Vector3 moveDirection = Vector3.forward; // 초기 이동 방향
    private float changeDirectionTime = 5f; // 방향 전환 시간 (5초)

    void Start()
    {
        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on this GameObject!");
        }

        // 5초마다 ChangeDirection 메서드를 호출
        InvokeRepeating("ChangeDirection", changeDirectionTime, changeDirectionTime);
    }

    void Update()
    {
        // 캐릭터 이동
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // 걷기 애니메이션 재생
        if (animator != null)
        {
            animator.SetFloat("Speed", moveSpeed > 0 ? 1f : 0f);
        }
    }

    // 이동 방향 변경
    void ChangeDirection()
    {
        // 랜덤한 방향으로 변경
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;

        Debug.Log($"New Direction: {moveDirection}");
    }
}
