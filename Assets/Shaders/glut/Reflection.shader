Shader "Custom/Reflection"
{
    Properties
    {
        //the base color of the material
        _Color("Color", Color) = (1,1,1,1)
        //Albedo (RGB) and Transparency (A) of the material
        _MainTex("Albedo (RGB)", 2D) = "white" {}
    //Smoothness of the material
    _Glossiness("Smoothness", Range(0,1)) = 0.5
        //Metalness of the material
        _Metallic("Metallic", Range(0,1)) = 0.0
        //Emission intensity of the material
        _intensity("Intensity", Range(0,1)) = 1.0
        //Reflection cubemap for the material
        _myCube("Reflection Map", Cube) = "grey" {}
    }
        SubShader
    {
        // Specifies the type of object to render
        Tags { "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //Declare the texture and cube map sampler variable
        sampler2D _MainTex;
        samplerCUBE _myCube;

        struct Input
        {
            // UV Texture coordinates for the main texture
            float2 uv_MainTex;
            //World reflection vector
            float3 worldRefl;
        };

        //Declare properties for the sub-shader
        half _Glossiness;
        half _Metallic;
        half _intensity;
        fixed4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // Sample the texture and multiply it by the color property to get the albedo
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            // Set the albedo color and multiply it by the intensity property
            o.Albedo = c.rgb * _intensity;
            // Set the metallic and smoothness properties
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            // Sample the cube map and set it as the emission color
            o.Emission = texCUBE(_myCube, IN.worldRefl).rgb;
            // Set the alpha channel from the texture
            o.Alpha = c.a;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
