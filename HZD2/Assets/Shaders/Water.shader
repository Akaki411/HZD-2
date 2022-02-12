Shader "Sprites/Water"
{
    Properties
    {
        _Intensity ("Intensity", Range(0, 0.4)) = 0.1
        _Speed ("Simulation speed", Range(0.1, 5)) = 1
        _Color ("Color", Color) = (1, 1, 1, 1)
        _MainTex("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Quene"="Opaque" "RenderType"="Background" }
        LOD 200

        CGPROGRAM

        #pragma surface surf Standard fullforwardshadows


        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Intensity;
        fixed _Speed;
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        
        UNITY_INSTANCING_BUFFER_START(Props)

        UNITY_INSTANCING_BUFFER_END(Props)

        

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed2 uv = IN.uv_MainTex;
            uv.y += sin(uv.x * 6.3 + _Time.y * _Speed) * _Intensity;
            uv.x += sin(uv.y * 6.3 + _Time.y * _Speed) * _Intensity;
            fixed4 c = tex2D (_MainTex, uv) * _Color;
            o.Albedo = c.rgb;

            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
