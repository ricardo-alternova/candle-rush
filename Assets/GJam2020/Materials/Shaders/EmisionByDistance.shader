Shader "Custom/EmissionByDistance"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_EmissionTex("Emision (RGB)", 2D) = "white" {}
		_EmissionValue("Emission", Float) = 1
		_Distance("Distance", Float) = 4
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_RangeEffect("RangeEffect", Range(0,2)) = 1.0
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert fullforwardshadows

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			half dist;
		};
		
		sampler2D _MainTex;
		sampler2D _EmissionTex;
		half _EmissionValue;
		half _Distance;
		float3 _AVATARposition;
		
		void surf(Input IN, inout SurfaceOutput o) 
		{
			half dist = max(0.0, _Distance - distance(IN.worldPos, _AVATARposition));

			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
			fixed3 emission = tex2D(_EmissionTex, IN.uv_MainTex).rgb;

			o.Albedo += emission * _EmissionValue * dist;
		}
		ENDCG
	}
	FallBack "Diffuse"
}