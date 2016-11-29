// Compiled shader for PC, Mac & Linux Standalone, uncompressed size: 23.6KB

// Skipping shader variants that would not be included into build of current scene.

Shader "Custom/GerbsAnimatedRift" {
	Properties{
		_TintColor("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex("Particle Texture", 2D) = "white" {}
		_InvFade("Soft Particles Factor", Range(0.01,3.0)) = 1.0

		//New stuff
		_EmissionTex("Emission (RGB)", 2D) = "black" {}
		_ScrollSpeedX("Scroll Speed X", Range(0,100)) = 0
		_ScrollSpeedY("Scroll Speed Y", Range(0,100)) = 0
		_EmissionIntensity("EmissionIntensity", Range(0,1)) = 0.0
		_EmissionMask("Emission Mask", 2D) = "white" {}
		//
	}

		Category{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Blend SrcAlpha One
		AlphaTest Greater .01
		ColorMask RGB
		Cull Off Lighting Off ZWrite Off Fog{ Color(0,0,0,0) }
		BindChannels{
		Bind "Color", color
		Bind "Vertex", vertex
		Bind "TexCoord", texcoord
	}

		// ---- Fragment program cards
		SubShader{
		Pass{

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#pragma multi_compile_particles

#include "UnityCG.cginc"

		sampler2D _MainTex;
		sampler2D _EmissionTex;
		sampler2D _EmissionMask;
		fixed4 _TintColor;

	struct appdata_t {
		float4 vertex : POSITION;
		fixed4 color : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	struct Input {
		float2 uv_EmissionTex;
		float2 uv_EmissionMask;
	};

	half _EmissionIntensity;
	float _ScrollSpeedX;
	float _ScrollSpeedY;

	struct v2f {
		float4 vertex : POSITION;
		fixed4 color : COLOR;
		float2 texcoord : TEXCOORD0;
#ifdef SOFTPARTICLES_ON
		float4 projPos : TEXCOORD1;
#endif
	};

	float4 _MainTex_ST;
	float4 uv_EmissionTex;
	float4 uv_EmissionMask;

	v2f vert(appdata_t v)
	{
		v2f o;
		o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
#ifdef SOFTPARTICLES_ON
		o.projPos = ComputeScreenPos(o.vertex);
		COMPUTE_EYEDEPTH(o.projPos.z);
#endif
		o.color = v.color;
		o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
		return o;
	}

	sampler2D _CameraDepthTexture;
	float _InvFade;

	fixed4 frag(v2f i) : COLOR
	{
#ifdef SOFTPARTICLES_ON
		float sceneZ = LinearEyeDepth(UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos))));
	float partZ = i.projPos.z;
	float fade = saturate(_InvFade * (sceneZ - partZ));
	//fixed2 scrolledUV = IN.uv_EmissionTex;
//	fixed xScrollValue = _ScrollSpeedX * _Time;
	//fixed yScrollValue = _ScrollSpeedY * _Time;
//	scrolledUV += fixed2(xScrollValue, yScrollValue);
	//fixed4 m = tex2D(_EmissionMask, IN.uv_EmissionMask);
//	fixed4 e = tex2D(_EmissionTex, scrolledUV) * _EmissionIntensity;
//	o.Emission = e * m;
//	i.color.a *= fade;
	void surf(Input IN, inout SurfaceOutputStandard o) {
		
		/* fixed2 scrolledUV = IN.uv_EmissionTex;

		fixed xScrollValue = _ScrollSpeedX * _Time;
		fixed yScrollValue = _ScrollSpeedY * _Time;

		scrolledUV += fixed2(xScrollValue, yScrollValue);*/
		

		// Albedo comes from a texture tinted by color
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		//fixed4 m = tex2D(_EmissionMask, IN.uv_EmissionMask);
		//fixed4 e = tex2D(_EmissionTex, scrolledUV) * _EmissionIntensity;
		//o.Emission = e * m;
	}
#endif

	return 2.0f * i.color * _TintColor * tex2D(_MainTex, i.texcoord);
	}
		ENDCG
	}
	}

		// ---- Dual texture cards
		SubShader{
		Pass{
		SetTexture[_MainTex]{
		constantColor[_TintColor]
		combine constant * primary
	}
		SetTexture[_MainTex]{

		combine texture * previous DOUBLE
	}
	}
	}

		// ---- Single texture cards (does not do color tint)
		SubShader{
		Pass{
		SetTexture[_MainTex]{
		combine texture * primary
	}
	}
	}
	}
}