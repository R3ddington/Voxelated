Shader "Custom/GerbsEmissionGlow" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Emission ("Emission", 2D) = "black" {}
		_Intensity("Emission Intensity", Range(0,2)) = 1
		_Freq("Freq", float) = 1
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
		sampler2D _Emission;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		float _Intensity;
		float _Freq;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			//float nFreq = _Freq * UNITY_PI * 2;
			//_Intensity += sin(_Intensity * nFreq + _Time);
			//_Intensity = Mathf.PingPong(Time.time, 2 - 1);
			float i = _Intensity;
			if (i > 2) {
				i = i - _SinTime.y;
			}
			else {
				i = i + _SinTime.y;
			}
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			fixed4 e = tex2D(_Emission, IN.uv_MainTex); // *_Intensity;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Emission = e * i;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
