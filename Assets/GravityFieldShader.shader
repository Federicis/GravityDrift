Shader "Custom/GradientCircleShader"
{
    Properties
    {
        _MainTex("Dummy Texture", 2D) = "white" {}
        _CenterColor("Center Color", Color) = (0, 0, 0, 1)
        _OuterColor("Outer Color", Color) = (1, 1, 1, 1)
        _Radius("Radius", Float) = 4
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
                float2 uv : TEXCOORD0;
                float4 localPos : TEXCOORD1;  // Local space position
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float2 localPos : TEXCOORD1;
            };

            float _Radius;
            float4 _CenterColor;
            float4 _OuterColor;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                // Pass local position to the fragment shader
                o.localPos = v.localPos.xy;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Center point in local space (0,0)
                float2 center = float2(0.5, 0.5);
                // Distance from the center
                float distanceFromCenter = distance(i.localPos, center);
                float ratio = saturate(distanceFromCenter / _Radius);

                fixed4 color = lerp(_CenterColor, _OuterColor, ratio);
                color.a = 0.5;
                return color;
            }
            ENDCG
        }
    }
}
