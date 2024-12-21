using UnityEngine;

public class LavaTextureFalling1 : MonoBehaviour
{
    [Header("Animation Settings")]
    public float fallSpeed = 0.2f; // 텍스처가 아래로 떨어지는 속도
    public string textureName = "_MainTex"; // 변경할 텍스처 이름 (Standard Shader는 "_MainTex")

    private Renderer rend;

    void Start()
    {
        // Renderer 컴포넌트를 가져옵니다.
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (rend != null && rend.material.HasProperty(textureName))
        {
            // 기존 UV Offset 값을 가져옵니다.
            Vector2 offset = rend.material.GetTextureOffset(textureName);

            // Y축 방향으로 Offset 값 조정 (위에서 아래로 떨어짐).
            offset.y += fallSpeed * Time.deltaTime;

            // Offset 값을 머티리얼에 적용합니다.
            rend.material.SetTextureOffset(textureName, offset);
        }
    }
}
