Shader "Custom/GhostlyStandardExperimental"
{
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("BaseColor (RGB)", 2D) = "white" {}
		//_Glossiness ("Smoothness (B)", 2D) = "black" {}
		//_Metallic ("Metallic (R)", 2D) = "black" {}
		_Normal ("Normal (RGB)", 2D) = "bump" {}
		_Emission ("Emission (RGB)", 2D) = "white" {}
		_EmissionColor ("Emission Color", Color) = (0,0,0,0)
		_EmissionIntensity ("EmissionIntensity", float) = 1.0

		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		_RimColorPow("GhostFade", Range (0,5)) = 2.5
		_RimHiLitePow("GhostHighlight", Range (0,5)) = 2.5

		_WarpTex ("Warping Texture (normal)", 2D) = "bump" {}
		_WarpStrength ("Warping Strength", float) = 1.0
		_ScrollXSpeed ("X direction", float) = 0.0
		_ScrollYSpeed ("Y direction", float) = 0.0
	}
	SubShader 
	{
		Tags{"RenderType" = "Transparent" "Queue" = "Transparent" "ForceNoShadowCasting" = "True"}
		LOD 200
		Pass
    	{
    		ColorMask 0
    	}
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		//#pragma surface surf Standard fullforwardshadows alpha:fade
		#pragma surface surf Standard alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		//sampler2D _Glossiness;
		//sampler2D _Metallic;
		sampler2D _Normal;
		sampler2D _Emission;
		sampler2D _WarpTex;

		struct Input 
		{
			float2 uv_MainTex;
			float2 uv_Normal;
			float2 uv_Emission;
			float2 uv_WarpTex;
			float3 viewDir;
		};

		half _Glossiness;
		half _Metallic;
		half _RimColorPow;
		half _RimHiLitePow;
		fixed4 _Color;
		half4 _EmissionColor;
		half _EmissionIntensity;

		half _WarpStrength;
		fixed _ScrollXSpeed;
		fixed _ScrollYSpeed;

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			fixed2 scrolledUV = IN.uv_WarpTex;
			
			fixed xScrollValue = _ScrollXSpeed * _Time;
			fixed yScrollValue = _ScrollYSpeed * _Time;
			
			scrolledUV += fixed2(xScrollValue, yScrollValue);


			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			//fixed4 m = tex2D (_Metallic, IN.uv_MainTex);
			half4 e = tex2D (_Emission, IN.uv_Emission) * _EmissionColor * _EmissionIntensity;
			half3 n = UnpackNormal (tex2D (_Normal, IN.uv_Normal));
			half3 w = UnpackNormal (tex2D (_WarpTex, scrolledUV));

			float3 combinedNormals;
			combinedNormals.r = n.r + (w.r * _WarpStrength);
			combinedNormals.g = n.g + (w.g * _WarpStrength);
			combinedNormals.b = n.b;

			o.Albedo = c.rgb*c.a;
			// Metallic and smoothness come from slider variables
			//o.Metallic = m.r;
			//o.Smoothness = m.a;
			o.Smoothness = _Glossiness;
			o.Metallic = _Metallic;
			o.Normal = combinedNormals;

			half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
			half rcp = pow (rim, _RimColorPow);
			half rhp = pow (rim, _RimHiLitePow);
			o.Emission = (e.rgb  * rcp + half4(1.0, 1.0, 1.0, 1.0) * rhp)  * e.a;

		  
			o.Alpha = c.a + ((e.a * rcp) + (e.a * rhp));
		}
		ENDCG
	}
	FallBack "Diffuse"
}
