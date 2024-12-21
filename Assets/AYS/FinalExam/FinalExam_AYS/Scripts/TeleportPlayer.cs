using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject miniMap;
    public Transform targetPosition;

    public void Teleport()
    {
        if (player != null && targetPosition != null)
        {
            CharacterController controller = player.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false; // CharacterController ��Ȱ��ȭ
                player.transform.position = targetPosition.position;
                controller.enabled = true;  // �ٽ� Ȱ��ȭ
                miniMap.SetActive(false);
            }
            else
            {
                player.transform.position = targetPosition.position;
            }

            Debug.Log("�÷��̾ �̵��߽��ϴ�: " + targetPosition.position);
        }
        else
        {
            Debug.LogWarning("�÷��̾ ��ǥ ��ġ�� �������� �ʾҽ��ϴ�.");
        }
    }
}