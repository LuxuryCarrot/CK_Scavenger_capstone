Shader "Custom/FOWShader"
{
    Properties
    {
        _Color ("Color", Color) = (0,0,0,1)
        _MainTex ("Focus (RGB) Trans (A)", 2D) = "white" {}
		_MainTex2("Gray (RGB) Trans (A)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        //LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:blend

        // Use shader model 3.0 target, to get nicer looking lighting
        //#pragma target 3.0

        sampler2D _MainTex;
		sampler2D _MainTex2;

        struct Input
        {
            float2 uv_MainTex;
        };

        /*half _Glossiness;
        half _Metallic;*/
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        //UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        //UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			fixed4 c2 = tex2D(_MainTex2, IN.uv_MainTex);
            o.Albedo = _Color;
            // Metallic and smoothness come from slider variables
            /*o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;*/
			float alpha = 1.0f - c.g*1.5f ;
            o.Alpha = alpha;
        }
        ENDCG
    }
    
}
