Shader "Custom/EmissionShader"
{
    Properties
    {
        _MainTex ("Base Texture (Albedo)", 2D) = "white" {}
        _EmissionMap ("Emission Texture", 2D) = "black" {}
        _EmissionColor ("Emission Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        sampler2D _EmissionMap;
        fixed4 _EmissionColor;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_EmissionMap;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Base Albedo Color
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;

            // Emission Effect
            fixed4 emission = tex2D(_EmissionMap, IN.uv_EmissionMap) * _EmissionColor;
            o.Emission = emission.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
