using UnityEngine;

public class LavaTextureFalling : MonoBehaviour
{
    [Header("Animation Settings")]
    public float fallSpeed = 0.2f; // �ؽ�ó�� �Ʒ��� �������� �ӵ�
    public string baseTextureName = "_MainTex"; // Base Texture �̸�
    public string emissionTextureName = "_EmissionMap"; // Emission Texture �̸�

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (rend != null)
        {
            // Base Texture UV Offset ����
            if (rend.material.HasProperty(baseTextureName))
            {
                Vector2 baseOffset = rend.material.GetTextureOffset(baseTextureName);
                baseOffset.y += fallSpeed * Time.deltaTime;
                rend.material.SetTextureOffset(baseTextureName, baseOffset);
            }

            // Emission Texture UV Offset ����
            if (rend.material.HasProperty(emissionTextureName))
            {
                Vector2 emissionOffset = rend.material.GetTextureOffset(emissionTextureName);
                emissionOffset.y += fallSpeed * Time.deltaTime;
                rend.material.SetTextureOffset(emissionTextureName, emissionOffset);
            }
        }
    }
}
