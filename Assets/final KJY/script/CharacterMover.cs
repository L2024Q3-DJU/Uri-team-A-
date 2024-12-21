using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float moveSpeed = 3f; // �̵� �ӵ�
    private Animator animator;
    private Vector3 moveDirection = Vector3.forward; // �ʱ� �̵� ����
    private float changeDirectionTime = 5f; // ���� ��ȯ �ð� (5��)

    void Start()
    {
        // Animator ������Ʈ ��������
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on this GameObject!");
        }

        // 5�ʸ��� ChangeDirection �޼��带 ȣ��
        InvokeRepeating("ChangeDirection", changeDirectionTime, changeDirectionTime);
    }

    void Update()
    {
        // ĳ���� �̵�
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // �ȱ� �ִϸ��̼� ���
        if (animator != null)
        {
            animator.SetFloat("Speed", moveSpeed > 0 ? 1f : 0f);
        }
    }

    // �̵� ���� ����
    void ChangeDirection()
    {
        // ������ �������� ����
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;

        Debug.Log($"New Direction: {moveDirection}");
    }
}
