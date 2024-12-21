using UnityEngine;

public class CameraFogController : MonoBehaviour
{
    public Camera playerCamera;   // Fog를 적용할 카메라
    public Camera otherCamera;    // Fog를 적용하지 않을 카메라

    private void OnEnable()
    {
        // 카메라 이벤트에 메서드 연결
        playerCamera.GetComponent<Camera>().enabled = true;
        otherCamera.GetComponent<Camera>().enabled = true;
    }

    void Update()
    {
        // 각 카메라에 맞게 Fog를 활성화하거나 비활성화
        if (Camera.current == playerCamera)
        {
            RenderSettings.fog = true; // Player Camera에서 Fog 활성화
        }
        else if (Camera.current == otherCamera)
        {
            RenderSettings.fog = false; // Other Camera에서 Fog 비활성화
        }
    }
}
