// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/VertexTransforms" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

        _Amplitude("Amplitude", Range(0, 1)) = 1.0

        _Frequency("Frequency", Float) = 0.0

        _XAmplitude("XAmplitude", Range(0, 0.1)) = 0.0
        _YawAmplitude("YawAmplitude", Range(0, 0.050)) = 0.0
        _RollAmplitude("RollAmplitude", Range(0, 0.050)) = 0.0
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert addshadow

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

        float _Amplitude;

        float _LocalZMin;
        float _LocalZMax;

        float _Frequency;

        float _XAmplitude;
        float _YawAmplitude;
        float _RollAmplitude;

        float _Acceleration;

        void vert (inout appdata_full v)
        {
            float3 localPos = v.vertex.xyz - mul(unity_ObjectToWorld, float4(0,0,0,1)).xyz;

            float vertexFrequency = sin((_Frequency + _Acceleration) * (sin(localPos.z) + _Time.y));

            float vertexXAmplitude    = _XAmplitude    * _Amplitude;
            float vertexYawAmplitude  = _YawAmplitude  * _Amplitude;
            float vertexRollAmplitude = _RollAmplitude * _Amplitude;

            float ampedYawRot   = vertexFrequency * -vertexYawAmplitude;
            float ampedRollRot  = vertexFrequency *  vertexRollAmplitude;

            float cosYaw  = cos(ampedYawRot);
            float sinYaw  = sin(ampedYawRot);
            float cosRoll = cos(ampedRollRot);
            float sinRoll = sin(ampedRollRot);
            
            float3x3 yaw = float3x3(float3( cosYaw, 0, sinYaw),
                                    float3(0, 1, 0),
                                    float3(-sinYaw, 0, cosYaw));

            float3x3 roll = float3x3(float3(cosRoll, -sinRoll, 0),
                                     float3(sinRoll,  cosRoll, 0),
                                     float3(0, 0, 1));

            // Transform position by rotation matrices
            v.vertex = float4(mul(roll, mul(yaw, v.vertex.xyz)), v.vertex.w);

            v.vertex.x += vertexFrequency * vertexXAmplitude;
        }

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
