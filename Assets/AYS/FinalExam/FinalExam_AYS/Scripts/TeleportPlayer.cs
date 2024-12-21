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
                controller.enabled = false; // CharacterController 비활성화
                player.transform.position = targetPosition.position;
                controller.enabled = true;  // 다시 활성화
                miniMap.SetActive(false);
            }
            else
            {
                player.transform.position = targetPosition.position;
            }

            Debug.Log("플레이어를 이동했습니다: " + targetPosition.position);
        }
        else
        {
            Debug.LogWarning("플레이어나 목표 위치가 설정되지 않았습니다.");
        }
    }
}