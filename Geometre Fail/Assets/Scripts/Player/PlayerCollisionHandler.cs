using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerDied;
    [SerializeField] private UnityEvent _squareCollected;

    [SerializeField] private float _scaleChangeDuration;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(GlobalConstants.ALLY_TAG))
        {
            AudioManager.Instance.PlaySFX("Point");
            collider.enabled = false;//�������� ���������, ����� �������� �� ��������� 2 ����.

            collider.transform
        .DOScale(Vector3.zero, _scaleChangeDuration)//������� ����� �� 0
                    .OnComplete(() =>
                    {
                        _squareCollected.Invoke();
                        Destroy(collider.gameObject);
                    });//�� ��������� �������� �������� ������
        }

        if (collider.CompareTag(GlobalConstants.ENEMY_TAG))
        {
            AudioManager.Instance.PlaySFX("Dead");
            _playerDied.Invoke();
            Destroy(collider.gameObject);
        }
    }
}
