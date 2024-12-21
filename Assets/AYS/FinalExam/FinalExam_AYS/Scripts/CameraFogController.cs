using UnityEngine;

public class CameraFogController : MonoBehaviour
{
    public Camera playerCamera;   // Fog�� ������ ī�޶�
    public Camera otherCamera;    // Fog�� �������� ���� ī�޶�

    private void OnEnable()
    {
        // ī�޶� �̺�Ʈ�� �޼��� ����
        playerCamera.GetComponent<Camera>().enabled = true;
        otherCamera.GetComponent<Camera>().enabled = true;
    }

    void Update()
    {
        // �� ī�޶� �°� Fog�� Ȱ��ȭ�ϰų� ��Ȱ��ȭ
        if (Camera.current == playerCamera)
        {
            RenderSettings.fog = true; // Player Camera���� Fog Ȱ��ȭ
        }
        else if (Camera.current == otherCamera)
        {
            RenderSettings.fog = false; // Other Camera���� Fog ��Ȱ��ȭ
        }
    }
}
