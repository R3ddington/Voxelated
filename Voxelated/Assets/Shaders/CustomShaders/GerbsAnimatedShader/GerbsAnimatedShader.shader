Shader "Custom/GerbsAnimatedShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_EmissionTex("Emission (RGB)", 2D) = "black" {}
		_ScrollSpeedX("Scroll Speed X", Range(0,100)) = 0
		_ScrollSpeedY("Scroll Speed Y", Range(0,100)) = 0
		_EmissionIntensity("EmissionIntensity", Range(0,1)) = 0.0
		_EmissionMask("Emission Mask", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _EmissionTex;
		sampler2D _EmissionMask;

		struct Input {
			float2 uv_MainTex;
			float2 uv_EmissionTex;
			float2 uv_EmissionMask;
		};

		half _EmissionIntensity;
		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		float _ScrollSpeedX;
		float _ScrollSpeedY;

		void surf (Input IN, inout SurfaceOutputStandard o) {

			fixed2 scrolledUV = IN.uv_EmissionTex;

			fixed xScrollValue = _ScrollSpeedX * _Time;
			fixed yScrollValue = _ScrollSpeedY * _Time;

			scrolledUV += fixed2(xScrollValue, yScrollValue);

			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			fixed4 m = tex2D(_EmissionMask, IN.uv_EmissionMask);
			fixed4 e = tex2D(_EmissionTex, scrolledUV) * _EmissionIntensity;
			o.Emission = e * m;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
