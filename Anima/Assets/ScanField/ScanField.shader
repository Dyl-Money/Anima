// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "4ik0/ScanField"
{
	Properties
	{
		_MainTex("Field texture", 2D) = "white" {}
		_RegularColor("Field color", Color) = (1, 0, 0, .2)
		_HighlightColor("Intersect Color", Color) = (1, 0, 0, .8)
		_HighlightThresholdMax("Scan thickness", Float) = .1
		_ScanSpeed("Texture offset", Vector) = (1, 3, 0, 0)
	}

	Category
	{
		Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }

		Blend One OneMinusSrcColor
		ColorMask RGB
		Cull Off Lighting Off ZWrite Off Fog{ Mode Off }

		SubShader
		{
			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_particles

				#include "UnityCG.cginc"

				sampler2D _MainTex;
				float4 _MainTex_ST;
				fixed4 _TintColor;
				fixed4 _ScanSpeed;
				uniform sampler2D _CameraDepthTexture; //Depth Texture
				uniform float4 _RegularColor;
				uniform float4 _HighlightColor;
				uniform float _HighlightThresholdMax;

				struct appdata_t
				{
					float4 vertex : POSITION;
					fixed4 color : COLOR;
					float2 texcoord : TEXCOORD0;
				};

				struct v2f
				{
					float4 vertex : SV_POSITION;
					fixed4 color : COLOR;
					float2 texcoord : TEXCOORD0;
					float4 projPos : TEXCOORD1;
				};

				v2f vert(appdata_t v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.projPos = ComputeScreenPos(o.vertex);
					o.color = v.color;
					o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
					return o;
				}

				half4 frag(v2f i) : COLOR
				{
					float4 finalColor;

					float sceneZ = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
					float partZ = i.projPos.w;
					float dist = sceneZ - partZ;
					float mult = pow(1 - saturate(dist / _HighlightThresholdMax), 3);
					fixed xScrollValue = _ScanSpeed.x * _Time.x;
					fixed yScrollValue = _ScanSpeed.y * _Time.x;
					half4 tex = tex2D(_MainTex, i.texcoord += half2(xScrollValue, yScrollValue));
					finalColor = i.color * tex * _RegularColor;
					finalColor.rgb *= finalColor.a;
					_HighlightColor *= _HighlightColor.a;

					return lerp(finalColor, _HighlightColor, mult);
				}

				ENDCG
			}
		}
	}
}
