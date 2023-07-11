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
		// ���b�N�I���V�X�e��
		LockOnSystem l = lockOnSystem.GetComponent<LockOnSystem>();

		// �G������Ƃ�
		if(l.getTarget() != null)
        {
			// ���b�N�I���}�[�J�[�̒u���ׂ����W���擾
			Vector2 position = RectTransformUtility.WorldToScreenPoint(Camera.main, l.getTarget().transform.position);
			this.transform.position = new Vector3(position.x, position.y, 0f);

			// ���b�N�I���}�[�J�[�̏�Ԕ���
			if (0 < l.getElapsedTime())
			{
				// lockOnCircle��
				if (l.getIsLockOn())
				{
					// ���b�N�I������
					this.gameObject.GetComponent<Image>().color = new Color(0f, 1f, 0f, 1f);//��
				}
				else
				{
					// ���b�N�I���r��
					this.gameObject.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);//��
				}
			}

			else
			{
				// lockOnCircle�O
				this.gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);//����(��\��)
			}
		}

		else
		{
			// lockOnCircle�O
			this.gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);//����(��\��)
		}
	}
}
