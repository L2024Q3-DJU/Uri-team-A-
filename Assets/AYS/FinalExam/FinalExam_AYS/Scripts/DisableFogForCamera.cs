using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MiniMapFogDisabler : MonoBehaviour
{
    private bool originalFogState;

    void OnPreRender()
    {
        // ���� �Ȱ� ���� ���� �� ��Ȱ��ȭ
        originalFogState = RenderSettings.fog;
        RenderSettings.fog = false;
    }

    void OnPostRender()
    {
        // �������� ���� �� ���� �Ȱ� ���� ����
        RenderSettings.fog = originalFogState;
    }
}
