using UnityEngine;

public class LavaFlow : MonoBehaviour
{
    public Material lavaMaterial;
    public float flowSpeed = 0.1f;
    private float offset;

    void Update()
    {
        offset += Time.deltaTime * flowSpeed;
        lavaMaterial.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}
