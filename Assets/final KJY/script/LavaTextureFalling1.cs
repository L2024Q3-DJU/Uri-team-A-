using UnityEngine;

public class LavaTextureFalling1 : MonoBehaviour
{
    [Header("Animation Settings")]
    public float fallSpeed = 0.2f; // �ؽ�ó�� �Ʒ��� �������� �ӵ�
    public string textureName = "_MainTex"; // ������ �ؽ�ó �̸� (Standard Shader�� "_MainTex")

    private Renderer rend;

    void Start()
    {
        // Renderer ������Ʈ�� �����ɴϴ�.
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (rend != null && rend.material.HasProperty(textureName))
        {
            // ���� UV Offset ���� �����ɴϴ�.
            Vector2 offset = rend.material.GetTextureOffset(textureName);

            // Y�� �������� Offset �� ���� (������ �Ʒ��� ������).
            offset.y += fallSpeed * Time.deltaTime;

            // Offset ���� ��Ƽ���� �����մϴ�.
            rend.material.SetTextureOffset(textureName, offset);
        }
    }
}
