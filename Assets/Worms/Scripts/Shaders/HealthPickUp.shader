Shader "Custom/HealthPickUp" {
	Properties {
		_HealthAmount ("HealthAmount", Range(0,1)) = 0.5
		_FullColor ("Color", Color) = (0,1,0,1)
		_EmptyColor ("Color", Color) = (1,0,0,1)
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows

		#pragma target 3.0

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _FullColor;
		fixed4 _EmptyColor;
		float _HealthAmount;

		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float4 c;
			if(IN.uv_MainTex.y <= _HealthAmount)
				c = _FullColor;
			else
				c = _EmptyColor;
			
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}