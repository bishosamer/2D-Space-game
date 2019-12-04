﻿Shader "Unlit/noiseApply"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	_noiseTex("Noise Texture",2D) = "black" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
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

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _noiseTex;
			
			v2f vert (appdata v)
			{
				v2f o;
				
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv  , _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
			
				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				//tex2D
				
				fixed4 noice = tex2D(_noiseTex, i.uv);
			float2 habd = (noice.r, noice.g);
				fixed4 col = tex2D(_MainTex, i.uv+habd);
				
				return col;
			}
			ENDCG
		}
	}
}
