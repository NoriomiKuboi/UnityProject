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
                half _BlurSize; // �c���̑傫��
                half _EdgeCoeff; // �c���͈̔�
                half2 _BlurCenterPoint; // �u���[�̒��S�_

                static const int sampleCount = 8; // �T���v�����O��
                static const float blurWeights[sampleCount] = { // �擾���Ă����F�ɂ�����W���̔z��
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount,
                    1.0 / sampleCount
                };

                // �x�N�g���̑傫���̌v�Z
                float norm(float2 vec) {
                    return max(abs(vec.x), abs(vec.y));
                }

                // �u���[�̒��S�_�܂ł̍ő勗��
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

                // �u���[�̒��S����Y���s�N�Z���܂ł̕����x�N�g��
                float2 dir = i.uv - _BlurCenterPoint;

                // �u���[�̒��S����̋����B�����������قǋ����u���[��������悤�ɂ���B
                float distance = norm(dir);

                // �����x�N�g���𐳋K��
                dir /= sqrt(dir.x * dir.x + dir.y * dir.y);

                // ��ʂ̒��S����ł������_�𐳋K��
                distance /= calcMaxDistance();

                distance = pow(distance, _EdgeCoeff); // ���[�̕��������u���[

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