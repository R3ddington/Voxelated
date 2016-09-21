Shader "Custom/GerbsRiftShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_EmissionTex("EmissionTexture", 2D) = "white" {}
		_Emission("Emission", Color) = (1,0,0,1)
		_EmissionIntensity("EmissionIntensity", Range(0,1)) = 0.0
		_NormalMap("Normal", 2D) = "bump" {}
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
		sampler2D _NormalMap;

		struct Input {
			float2 uv_MainTex;
			float2 uv_EmissionTex;
			float2 uv_NormalMap;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _Emission;
		half _EmissionIntensity;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;

			fixed4 e = tex2D (_EmissionTex, IN.uv_EmissionTex) * _Emission;
			o.Emission = e.rgb * _EmissionIntensity;
			o.Alpha = c.a;

			fixed3 n = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
			o.Normal = n;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
