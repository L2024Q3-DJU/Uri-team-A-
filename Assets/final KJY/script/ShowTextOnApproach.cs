using UnityEngine;

public class ShowTextOnApproach : MonoBehaviour
{
    public GameObject textObject; // 표시할 텍스트 오브젝트
    public string playerTag = "Player"; // 플레이어 태그

    void Start()
    {
        if (textObject != null)
        {
            textObject.SetActive(false); // 텍스트 초기 상태 비활성화
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 Trigger 영역에 들어올 경우
        if (other.CompareTag(playerTag) && textObject != null)
        {
            textObject.SetActive(true); // 텍스트 활성화
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어가 Trigger 영역을 나갈 경우
        if (other.CompareTag(playerTag) && textObject != null)
        {
            textObject.SetActive(false); // 텍스트 비활성화
        }
    }
}
