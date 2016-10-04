Shader "Custom/GerbsUltimateShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("MetallicIntensity", Range(0,1)) = 0.0
		_MetallicMap("MettalicMap", 2D) = "white" {}
		_EmissionTex("EmissionTexture", 2D) = "white" {}
		_Emission("EmissionColor", Color) = (1,0,0,1)
		_EmissionIntensity("EmissionIntensity", Range(0,1)) = 0.0
		_NormalMap("Normal", 2D) = "bump" {}
		_NormalMap2("Normal2", 2D) = "bump" {}
		_NormalIntensity("NormalIntensity", Range(0,1)) = 0.0
		_Normal2Intensity("Normal2Intensity", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MetallicMap;
		sampler2D _EmissionTex;
		sampler2D _NormalMap;
		sampler2D _NormalMap2;

		struct Input {
			float2 uv_MetallicMap;
			float2 uv_EmissionTex;
			float2 uv_NormalMap;
			float2 uv_NormalMap2;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _Emission;
		half _EmissionIntensity;
		half _NormalIntensity;
		half _Normal2Intensity;


		void surf (Input IN, inout SurfaceOutputStandard o) {
			//Color
			o.Albedo = _Color;
			// Metallic and smoothness come from slider variables
			fixed4 m = tex2D(_MetallicMap, IN.uv_MetallicMap);
			o.Metallic = m * _Metallic;
			o.Smoothness = _Glossiness;
			//Emission
			fixed4 e = tex2D(_EmissionTex, IN.uv_EmissionTex) * _Emission;
			o.Emission = e.rgb * _EmissionIntensity;
			//Alpha
			o.Alpha = _Color.a;
			//Normal Maps
			fixed3 n = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap)) * _NormalIntensity;
			fixed3 n2 = UnpackNormal(tex2D(_NormalMap2, IN.uv_NormalMap2)) * _Normal2Intensity;
			o.Normal = n + n2;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
