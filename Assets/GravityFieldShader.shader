Shader "Custom/GradientCircleShader"
{
    Properties
    {
        _MainTex("Dummy Texture", 2D) = "white" {}
        _CenterColor("Center Color", Color) = (0, 0, 0, 0.32)
        _OuterColor("Outer Color", Color) = (1, 1, 1, 0.32)
        _Radius("Radius", Float) = 0.5
    }

    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            float _Radius;
            float4 _CenterColor;
            float4 _OuterColor;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy * 0.5 + 0.5;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float distanceFromCenter = distance(i.uv, float2(0.5, 0.5));
                float ratio = saturate(distanceFromCenter / _Radius);

                fixed4 color = lerp(_CenterColor, _OuterColor, ratio);
                //color.a = 0.32;
                return color;
            }
            ENDCG
        }
    }
}
