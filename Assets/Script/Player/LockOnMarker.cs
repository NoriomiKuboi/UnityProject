using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockOnMarker : MonoBehaviour
{
	public GameObject lockOnSystem;

	void Start()
	{
		this.gameObject.GetComponent<Image>().color = new Color(0f, 1f, 0f, 0f);
	}

	void Update()
	{
		// ロックオンシステム
		LockOnSystem l = lockOnSystem.GetComponent<LockOnSystem>();

		// 敵がいるとき
		if(l.getTarget() != null)
        {
			// ロックオンマーカーの置くべき座標を取得
			Vector2 position = RectTransformUtility.WorldToScreenPoint(Camera.main, l.getTarget().transform.position);
			this.transform.position = new Vector3(position.x, position.y, 0f);

			// ロックオンマーカーの状態判定
			if (0 < l.getElapsedTime())
			{
				// lockOnCircle内
				if (l.getIsLockOn())
				{
					// ロックオン完了
					this.gameObject.GetComponent<Image>().color = new Color(0f, 1f, 0f, 1f);//緑
				}
				else
				{
					// ロックオン途中
					this.gameObject.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);//赤
				}
			}

			else
			{
				// lockOnCircle外
				this.gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);//透明(非表示)
			}
		}

		else
		{
			// lockOnCircle外
			this.gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);//透明(非表示)
		}
	}
}
