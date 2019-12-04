Shader "Unlit/mixBG"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_MixTex("Texture ",2D) = "white"{}
		_ScrollIntensity("Intensity",float)  =0.1
		_ScrollSpeedDamper("Switch Speed",float) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" }
		LOD 100	

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex, _MixTex;
			float4 _MainTex_ST;
			float _ScrollIntensity, _ScrollSpeedDamper;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				
				float4 color= (_ScrollIntensity * sin(_Time* _ScrollSpeedDamper));
				
				fixed4 col = lerp(tex2D(_MainTex, i.uv),tex2D(_MixTex,i.uv),color);
				
				
			
				return col;
			}
			ENDCG
		}
	}
}
