  Shader "Custom/No Normals 4 Vertex Color Only Vertex Cutout" {
    Properties {
     _MainTex ("Texture", 2D) = "white" {}
	_LightCutoff("Maximum distance", Float) = 2.0
	  _Color ("Main Color", Color) = (1,1,1,1)
	   _SliceGuide ("Slice Guide (RGB)", 2D) = "white" {}
	    _SliceAmount ("Slice Amount", Range(0.0, 1.0)) = 0.5

    }
    SubShader {
      Tags { "RenderType" = "Opaque"  }
     
		Cull off
//		Blend SrcAlpha OneMinusSrcAlpha
      CGPROGRAM		
      	#pragma surface surf WrapLambert fullforwardshadows
		
		uniform float _LightCutoff;
		uniform float4 _Color;
		
      	half4 LightingWrapLambert (SurfaceOutput s, half3 lightDir, half atten) {
          half NdotL = dot (s.Normal, lightDir);

		  	atten = step(_LightCutoff, atten) * atten;
          	half4 c;
          	c.rgb = s.Albedo * _LightColor0.rgb * atten;
          	c.a = s.Alpha;
          	return c;
      }

      struct Input {
          float2 uv_MainTex;
          float4 color : COLOR; //vertex color
          float2 uv_SliceGuide;
          float _SliceAmount;
      };
       		
	  
      sampler2D _MainTex;
        sampler2D _SliceGuide;
      float _SliceAmount;
      void surf (Input IN, inout SurfaceOutput o) {
       	clip(tex2D (_SliceGuide, IN.uv_SliceGuide).rgb - _SliceAmount);
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb *  IN.color.rgb * _Color;
//          o.Alpha = _Color.a * IN.color.a * tex2D (_MainTex, IN.uv_MainTex).a;
          
      }
      ENDCG
    }
    Fallback "Diffuse"
  }