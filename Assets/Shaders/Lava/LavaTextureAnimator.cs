using UnityEngine;

public class LavaTextureAnimator : MonoBehaviour
{
    [Header("Animation Settings")]
    public Vector2 scrollSpeed = new Vector2(0.1f, -0.1f); // 텍스처 흐름 속도
    public string textureName = "_MainTex"; // 변경할 텍스처의 이름 (Standard Shader: "_MainTex")

    private Renderer rend; // Renderer 컴포넌트

    void Start()
    {
        // Renderer 컴포넌트를 가져옵니다.
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (rend != null && rend.material.HasProperty(textureName))
        {
            // 기존 Offset 값을 가져옵니다.
            Vector2 offset = rend.material.GetTextureOffset(textureName);

            // 시간에 따라 Offset 값을 업데이트합니다.
            offset += scrollSpeed * Time.deltaTime;

            // 업데이트된 Offset 값을 머티리얼에 적용합니다.
            rend.material.SetTextureOffset(textureName, offset);
        }
    }
}
