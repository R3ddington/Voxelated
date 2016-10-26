Shader "Custom/GerbsWaterShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_NormalMap1("Normal1", 2D) = "bump" {}
		_NormalMap2("Normal2", 2D) = "bump" {}
		_NormalIntensity1("Normal1Intensity", Range(0,1)) = 0.0
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

		sampler2D _MainTex;
		sampler2D _NormalMap1;
		sampler2D _NormalMap2;

		struct Input {
			float2 uv_MainTex;
			float2 uv_NormalMap1;
			float2 uv_NormalMap2;
		};

		half _Glossiness;
		half _Metallic;
		half _Normal1Intensity;
		half _Normal2Intensity;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			
			//Normal maps
			fixed3 n1 = UnpackNormal(tex2D(_NormalMap1, IN.uv_NormalMap1)); //*_Normal1Intensity;
			fixed3 n2 = UnpackNormal(tex2D(_NormalMap2, IN.uv_NormalMap2)); // *_Normal2Intensity;
			fixed3 n = normalize (fixed3(n1.r + n2.r, n1.g + n2.g, n1.b));
			o.Normal = n;
			
		}
		ENDCG
	}
	FallBack "Diffuse"
}
