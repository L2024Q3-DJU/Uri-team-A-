using UnityEngine;
using System.Collections.Generic;

public class Portal : MonoBehaviour
{
    public GameObject miniMap; // 미니맵 오브젝트
    public List<GameObject> portalObjects; // 포탈 포인트와 연결된 오브젝트 리스트
    public MonoBehaviour playerMovementScript; // 플레이어 움직임 스크립트 (FirstPersonController 등)
    public KeyCode toggleKey = KeyCode.F; // 미니맵 토글 키

    private bool isMiniMapOpen = false; // 미니맵 상태를 추적
    private bool isPlayerInPortalPoint = false; // 플레이어가 PortalPoint 안에 있는지 여부

    void Start()
    {
        // 초기 상태: 미니맵 비활성화
        miniMap.SetActive(false);

        // 모든 포탈 오브젝트를 비활성화
        foreach (GameObject obj in portalObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                Debug.Log($"{obj.name} 오브젝트가 비활성화되었습니다."); // 디버깅
            }
        }

        // 플레이어 움직임 활성화 (초기화)
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true;
        }

        // 초기 마우스 상태 설정
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // F 키 입력으로 미니맵 열기/닫기 (PortalPoint 안에 있을 때만)
        if (Input.GetKeyDown(toggleKey) && isPlayerInPortalPoint)
        {
            ToggleMiniMap();
        }
    }

    public void ToggleMiniMap()
    {
        // 미니맵 상태 전환
        isMiniMapOpen = !isMiniMapOpen;
        miniMap.SetActive(isMiniMapOpen);

        // 플레이어 움직임 제어
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = !isMiniMapOpen; // 미니맵이 열리면 비활성화
        }

        // 마우스 상태 제어
        if (isMiniMapOpen)
        {
            Cursor.lockState = CursorLockMode.None; // 마우스 락 해제
            Cursor.visible = true; // 마우스 포인터 보이기
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // 마우스 락 설정
            Cursor.visible = false; // 마우스 포인터 숨기기
        }

        Debug.Log($"미니맵 상태: {isMiniMapOpen}, 플레이어 움직임 활성화: {!isMiniMapOpen}");
    }

    private void OnTriggerEnter(Collider other)
    {
        // 포탈 포인트에 진입했을 때
        if (other.CompareTag("PortalPoint"))
        {
            isPlayerInPortalPoint = true; // PortalPoint 안으로 진입
            ActivatePortalObject();
        }

        // 플레이어가 포탈에 진입했을 때
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);

            // 텔레포트 후 PortalPoint 상태 초기화
            isPlayerInPortalPoint = false;

            // 플레이어 움직임 스크립트 다시 활성화
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = true; // 즉시 움직임 활성화
            }

            // 마우스 상태 초기화
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Debug.Log("플레이어가 텔레포트된 후 움직임이 활성화되었습니다.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 포탈 포인트를 벗어났을 때
        if (other.CompareTag("PortalPoint"))
        {
            isPlayerInPortalPoint = false; // PortalPoint 밖으로 나감
            DeactivatePortalObject();
        }
    }

    private void ActivatePortalObject()
    {
        foreach (GameObject obj in portalObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true); // 오브젝트 활성화
                Debug.Log($"{obj.name} 오브젝트가 활성화되었습니다."); // 디버깅
            }
        }
    }

    private void DeactivatePortalObject()
    {
        foreach (GameObject obj in portalObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false); // 오브젝트 비활성화
                Debug.Log($"{obj.name} 오브젝트가 비활성화되었습니다."); // 디버깅
            }
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        // 현재 포탈 위치로 플레이어를 이동
        player.transform.position = transform.position + Vector3.forward * 2; // 예: 포탈 위치 앞쪽으로 이동
        Debug.Log($"{player.name}가 텔레포트되었습니다: {player.transform.position}");
    }
}
