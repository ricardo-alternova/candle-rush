Shader "Custom/DoorAndKeyShader"
{
    Properties
    {
        [HDR] _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _LightTex ("Lights", 2D) = "white" {}
        _Open ("Open", Range(0,0.2)) = 0

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _LightTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Open;
        fixed4 _Color;


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            float light1 = tex2D (_LightTex, IN.uv_MainTex).b;
            float light2 = tex2D (_LightTex, IN.uv_MainTex).r;

            light2 = ((light2)*(light2)*_Open*360);

            if(light2 >= 1)
            {
                light2 = 1;     
			}

            float lightRes = light1 + light2;

            o.Albedo = c.rgb;
            o.Emission = lightRes * _Color;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
