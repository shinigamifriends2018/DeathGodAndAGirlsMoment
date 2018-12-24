﻿// Unlit alpha-cutout shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "Custom/Unlit/ Transparent Cutout" {
	Properties{
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
	_Cutoff("Alpha cutoff", Range(0,1)) = 0.5
	}

		SubShader{
		Tags{ "Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout" }
		LOD 100
		Cull Off

		Pass{
		Lighting Off
		Alphatest Greater[_Cutoff]
		SetTexture[_MainTex]{ combine texture }
	}
	}
}