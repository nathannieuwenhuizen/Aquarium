Shader "Custom/UnderWaterEffect" {
	Properties{
		_ScreenTint("Screen Tint", Color) = (0, 0, 0, .001)
		_MainTex("Screen Texture", 2D) = "white" {}

		_HeavynessMultiplyer("Heavyness multiplyer", range(20, 80)) = 50
	}

		SubShader{

			Pass {
				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag

				fixed4 _ScreenTint;
				sampler2D _MainTex;
				sampler2D _WaterTexture;
				float _HeavynessMultiplyer;
			
			struct appdata {
				float2 uv: TEXCOORD0;
				float4 vertex : POSITION;
			};
			
			struct v2f {
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};



			v2f vert(appdata v) 
			{
				v2f o;

				v.uv.y += sin(v.uv.x + _Time.y)/ _HeavynessMultiplyer;

				fixed4 pixelColor = tex2Dlod(_WaterTexture, float4(v.uv, 0, 0));
				
				//v.uv.x += pixelColor.b/10;

				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;


				return o;
			}


			fixed4 frag (v2f i) : SV_Target 
			{
				fixed4 color = tex2D(_MainTex, i.uv);



				float4 finalColor = _ScreenTint.rgba;

				color.rgba *= finalColor;
				return color;
			}


			ENDCG
		}

	}
}