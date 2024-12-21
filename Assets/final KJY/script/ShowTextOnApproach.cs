using UnityEngine;

public class ShowTextOnApproach : MonoBehaviour
{
    public GameObject textObject; // ǥ���� �ؽ�Ʈ ������Ʈ
    public string playerTag = "Player"; // �÷��̾� �±�

    void Start()
    {
        if (textObject != null)
        {
            textObject.SetActive(false); // �ؽ�Ʈ �ʱ� ���� ��Ȱ��ȭ
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ Trigger ������ ���� ���
        if (other.CompareTag(playerTag) && textObject != null)
        {
            textObject.SetActive(true); // �ؽ�Ʈ Ȱ��ȭ
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �÷��̾ Trigger ������ ���� ���
        if (other.CompareTag(playerTag) && textObject != null)
        {
            textObject.SetActive(false); // �ؽ�Ʈ ��Ȱ��ȭ
        }
    }
}
