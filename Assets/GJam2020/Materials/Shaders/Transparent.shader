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

//	SubShader
//	{
//		Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
//		LOD 200
//
//			
//
//		// extra pass that renders to depth buffer only
//		Pass {
//			ZWrite On
//			ColorMask 0
//
//			Material
//		{
//			Diffuse[_Color]
//			Emission[_Emission]
//		}
//			SetTexture[_MainTex] {
//				constantColor[_Color]
//				Combine texture * primary DOUBLE, texture * constant
//			}
//		}
//
//		// paste in forward rendering passes from Transparent/Diffuse
//		UsePass "Transparent/Diffuse/FORWARD"
//	}
//				
//    FallBack "Diffuse"
//}


	SubShader{
		Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 200
			
		Pass 
		{
			ZWrite On
			ColorMask 0
		}

		UsePass "Transparent/Diffuse/FORWARD"

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
