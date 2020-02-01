Shader "Custom/DisplaceByDistance"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _ZMultiplier("Distance multiplier", float) = 1
        _FlexMultiplier("Flex multiplier", float) = 1
        _RangeEffect("RangeEffect", Range(0,2)) = 1.0
        _GroundHeight("Ground height", float) = 0.0
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert addshadow

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float4 _AVATARposition;
        half _RangeEffect;
        half _ZMultiplier;
        half _FlexMultiplier;
        half _GroundHeight;

        struct appdata {
            float4 vertex : POSITION;
            float2 texcoord : TEXCOORD0;
            float3 normal : NORMAL;
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void vert(inout appdata v) {
            float4 objectWorldPos = mul(unity_ObjectToWorld, v.vertex);

            float4 centerObjectWorld = mul(unity_ObjectToWorld, float4(0, 0.0, 0, 1));
            half2 direction = normalize(centerObjectWorld.xz - _AVATARposition.xz);

            float dist = distance(objectWorldPos, _AVATARposition);
            half effect = 1 - saturate(dist / _RangeEffect);

            half yDist = objectWorldPos.y - _GroundHeight;
            yDist *= yDist > 0;

            objectWorldPos.xz += effect * direction * _FlexMultiplier * yDist;
            objectWorldPos.y -= effect * _ZMultiplier * yDist;

            v.vertex = mul(unity_WorldToObject, objectWorldPos);
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
