// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Transparent"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
		[HDR]_EmissionColor("Emmisive Color", Color) = (0,0,0,0)
    }

	SubShader{
		Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 200
			
		Pass 
		{
			ZWrite On
			ColorMask 0
		}

		//ZWrite On
		//Blend SrcAlpha OneMinusSrcAlpha
		ColorMask RGB

		CGPROGRAM
		#pragma surface surf Lambert alpha:fade
		struct Input {
			float2 uv_MainTex;
		};
		sampler2D _MainTex;
		float4 _EmissionColor;
		float4 _Color;

		void surf(Input IN, inout SurfaceOutput o) {
			  
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _Color;
			o.Emission = _EmissionColor ;
			o.Alpha = _Color.a;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
