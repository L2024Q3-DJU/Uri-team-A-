using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MiniMapFogDisabler : MonoBehaviour
{
    private bool originalFogState;

    void OnPreRender()
    {
        // 현재 안개 상태 저장 및 비활성화
        originalFogState = RenderSettings.fog;
        RenderSettings.fog = false;
    }

    void OnPostRender()
    {
        // 렌더링이 끝난 후 원래 안개 상태 복원
        RenderSettings.fog = originalFogState;
    }
}
