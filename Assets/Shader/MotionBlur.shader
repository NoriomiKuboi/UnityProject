Shader "Unlit/MotionBlur"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _BlurSize("Blur Size", Float) = 0
        _EdgeCoeff("Edge Coefficient", Float) = 1
        _BlurCenterPoint("Blur Center Point", Vector) = (0.5, 0.5, 0.0)
    }

        SubShader
        {
            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                sampler2D _MainTex;
                half _BlurSize; // 残像の大きさ
                half _EdgeCoeff; // 残像の範囲
                half2 _BlurCenterPoint; // ブラーの中心点

                static const int sampleCount = 8; // サンプリング数
                static const float blurWeights[sampleCount] = { // 取得してきた色にかける係数の配列
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount
                };

                // ベクトルの大きさの計算
                float norm(float2 vec) {
                    return max(abs(vec.x), abs(vec.y));
                }

                // ブラーの中心点までの最大距離
                float calcMaxDistance()
                {
                    float distance1 = norm(float2(0, 0) - _BlurCenterPoint);
                    float distance2 = norm(float2(1, 0) - _BlurCenterPoint);
                    float distance3 = norm(float2(0, 1) - _BlurCenterPoint);
                    float distance4 = norm(float2(1, 1) - _BlurCenterPoint);

                    float maxDistance = max(distance1, max(distance2, max(distance3, distance4)));

                    return maxDistance;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                        fixed4 col = 0;

                // ブラーの中心から該当ピクセルまでの方向ベクトル
                float2 dir = i.uv - _BlurCenterPoint;

                // ブラーの中心からの距離。距離が遠いほど強くブラーがかかるようにする。
                float distance = norm(dir);

                // 方向ベクトルを正規化
                dir /= sqrt(dir.x * dir.x + dir.y * dir.y);

                // 画面の中心から最も遠い点を正規化
                distance /= calcMaxDistance();

                distance = pow(distance, _EdgeCoeff); // より端の方だけをブラー

                for (int j = 0; j < sampleCount; j++) {
                    float2 samplePoint = i.uv - dir / sampleCount * j * distance * _BlurSize;
                    col += tex2D(_MainTex, samplePoint) * blurWeights[j];
                }

                return col;
            }
        ENDCG
        }
    }
}