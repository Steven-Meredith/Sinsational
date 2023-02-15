Shader "Custom/Rim Lighting"
{
    Properties
    {
        //The colour of the Hologram Rim
        _RimColor("Rim Colour", Color) = (0, 0.5, 0.5, 0)
        //The intensity of the Hologram Rim 
        _RimPower("Rim Power", Range(0.5, 8.0)) = 3.0
    }
        SubShader
    {
        //Set the render queue to Transparent
         Tags { "Queue" = "Geometry" }
        LOD 200 //Specifies the lvl of detail

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade //Specifies the surface shader type

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //A texture sampler used for texture mapping
        sampler2D _MainTex;

        struct Input
        {
            //The view direction of the camera
            float3 viewDir;
        };

        //Define the shader variables
        float4 _RimColor;
        float _RimPower;

        void surf(Input IN, inout SurfaceOutput o)
        {
            //Calculate the rim effect based on the dot product of the view direction and surface normal
            half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
            //Calculate the hologram rim color and intensity and assign it to the surface emission color
            o.Emission = _RimColor.rgb * pow(rim, _RimPower) * 10;
            o.Alpha = pow(rim, _RimPower); //Add the the output to match the power in order to remove the inner solid part.
        }
        ENDCG
    }
        FallBack "Diffuse"
}