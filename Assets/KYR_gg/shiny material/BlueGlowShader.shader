Shader "Custom/BlueGlowShader"
{
    Properties
    {
        _Color("Glow Color", Color) = (0, 0.5, 1, 1) // 기본 파란색
        _GlowIntensity("Glow Intensity", Range(0, 5)) = 2.0 // 빛나는 강도
    }

    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha One      // Additive Blending (빛나게 만듦)
            ZWrite Off              // 깊이 버퍼 비활성화
            Cull Off                // 양면 렌더링

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            fixed4 _Color;
            float _GlowIntensity;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // 파란색과 빛의 강도를 적용
                fixed4 glow = _Color * _GlowIntensity;
                glow.a = _Color.a; // 투명도 유지
                return glow;
            }
            ENDCG
        }
    }
}
