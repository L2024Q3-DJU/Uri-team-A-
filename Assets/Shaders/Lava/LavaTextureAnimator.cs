using UnityEngine;

public class LavaTextureAnimator : MonoBehaviour
{
    [Header("Animation Settings")]
    public Vector2 scrollSpeed = new Vector2(0.1f, -0.1f); // �ؽ�ó �帧 �ӵ�
    public string textureName = "_MainTex"; // ������ �ؽ�ó�� �̸� (Standard Shader: "_MainTex")

    private Renderer rend; // Renderer ������Ʈ

    void Start()
    {
        // Renderer ������Ʈ�� �����ɴϴ�.
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (rend != null && rend.material.HasProperty(textureName))
        {
            // ���� Offset ���� �����ɴϴ�.
            Vector2 offset = rend.material.GetTextureOffset(textureName);

            // �ð��� ���� Offset ���� ������Ʈ�մϴ�.
            offset += scrollSpeed * Time.deltaTime;

            // ������Ʈ�� Offset ���� ��Ƽ���� �����մϴ�.
            rend.material.SetTextureOffset(textureName, offset);
        }
    }
}
