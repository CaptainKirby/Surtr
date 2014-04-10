// Unlit shader. Simplest possible textured shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "Mirror" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_ReflectionTex ("Reflection", 2D) = "white" { TexGen ObjectLinear }
	_Color ("Main Color", COLOR) = (1,1,1,1)
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 100
	
	Pass {
	Material {
                Diffuse [_Color]
                Ambient [_Color]
            }
        SetTexture[_MainTex] 
        { 
          constantColor [_Color]
          combine constant lerp(texture) previous
//        	Combine texture
        }
        SetTexture[_ReflectionTex] 
        {
        	matrix [_ProjMatrix] combine texture + previous 
        }
    }
}

// fallback: just main texture
Subshader {
	Tags { "RenderType"="Opaque" }
	LOD 100
	
    Pass {
        SetTexture [_MainTex] { combine texture }
    }
}
}