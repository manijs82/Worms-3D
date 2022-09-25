Shader "Unlit/HealthBar"
{
	Properties
	{
		_HealthAmount ("", Range(0,1)) = 0.5
		_HealthColor ("HealthColor", Color) = (0,1,0,1)
		_EmptyColor ("EmptyColor", Color) = (1,0,0,1)
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
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			float _HealthAmount;
			float4 _HealthColor; 
			float4 _EmptyColor;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			float4 frag (v2f i) : SV_Target
			{
				float4 color;
				if(i.uv.x <= _HealthAmount)
					color = _HealthColor;
				else
					color = _EmptyColor;
				
				return color;
			}
			ENDCG
		}
	}
}