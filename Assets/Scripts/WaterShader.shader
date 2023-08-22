//UNITY_SHADER_NO_UPGRADE

Shader "Custom/WaterShader"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_Steepness ("Steepness", Range(0, 1)) = 0.5
		_Wavelength ("Wavelength", Float) = 10
		_RippleAmplitude ("Ripple Amplitude", Float) = 1
		_RippleSpeed ("Ripple Speed", Float) = 1
		_RippleFrequency ("Ripple Frequency", Float) = 1
		_CharacterWaveAmplitude1 ("_CharacterWaveAmplitude1", float) = 0
		_CharacterWaveAmplitude2 ("_CharacterWaveAmplitude2", float) = 0
	}
	SubShader
	{
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
		Pass
		{
			Cull Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			fixed4 _Color;
			float _Steepness, _Wavelength;
			float _RippleAmplitude, _RippleSpeed, _RippleFrequency;
			float _CharacterWaveAmplitude1, _CharacterWaveAmplitude2;
			float _ImpactX1, _ImpactZ1, _ImpactX2, _ImpactZ2;
			float _Distance1, _Distance2;

			struct vertIn
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			float4 getWaves(float x) {
				float k = 2 * UNITY_PI / _Wavelength;
				float speed = sqrt(9.8 / k);
				float f = k * (x - speed * _Time.y);
				float waveAmplitude = _Steepness / k;
				float waveChangeY = waveAmplitude * sin(f);
				float4 waves = float4(0.0f, waveChangeY, 0.0f, 0.0f);
				waves.x += waveAmplitude * cos(f);
				return waves;
			}

			float4 getCollisionRipples(float x, float z) {
				float xOffset1 = _ImpactX1;
				float zOffset1 = _ImpactZ1;
				float f1 = (pow(x - xOffset1, 2) + pow(z - zOffset1, 2));
				float ripple1 = _RippleAmplitude * sin(_RippleSpeed * _Time.w  + _RippleFrequency * f1);
				float xOffset2 = _ImpactX2;
				float zOffset2 = _ImpactZ2;
				float f2 = (pow(x - xOffset2, 2) + pow(z - zOffset2, 2));
				float ripple2 = _RippleAmplitude * sin(_RippleSpeed * _Time.w  + _RippleFrequency * f2);
				float4 ripples = float4(0.0f, 0.0f, 0.0f, 0.0f);

				if (sqrt(pow(x - _ImpactX1, 2) + pow(z - _ImpactZ1, 2)) < _Distance1) {
					ripples += ripple1 * _CharacterWaveAmplitude1;
				}	
				if (sqrt(pow(x - _ImpactX2, 2) + pow(z - _ImpactZ2, 2)) < _Distance2) {
					ripples += ripple2 * _CharacterWaveAmplitude2;
				}
				return ripples;
			}

			// Implementation of the vertex shader
			vertOut vert(vertIn v)
			{
				// Convert vertices into world space
				float4 worldSpace = mul(unity_ObjectToWorld, v.vertex);

				// Add waves
				float4 waves = getWaves(worldSpace.x);
				worldSpace += waves;

				// Add ripples
				float4 ripples = getCollisionRipples(worldSpace.x, worldSpace.z);
				worldSpace.y += ripples;

				// Convert vertices to screen coordinates
				vertOut o;
				o.vertex = mul(UNITY_MATRIX_VP, worldSpace);
				o.uv = v.uv;
				return o;
			}
			
			// Implementation of the fragment shader
			fixed4 frag(vertOut v) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, v.uv);
				return col * _Color;
			}
			ENDCG
		}
	}
}