using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _leftBorderRange; //левая граница бокса игрока
    [SerializeField] private Transform _rightBorderRange; //правая граница бокса игрока

    [SerializeField] private float _speed; //скорость игрока

    private bool _isMovingRight; //направление движения игрока
    private float _oneWayTime; //время прохождения пути
    private float _currentTime; //текущее время


    private void Awake()
    {
        _oneWayTime = Vector3.Distance(_leftBorderRange.position, _rightBorderRange.position) / _speed;
        _currentTime = Vector3.Distance(_leftBorderRange.position, transform.position) / _speed;
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.BORDER_TAG))
        {
            AudioManager.Instance.PlaySFX("Rebound");
        }
        if (collision.CompareTag(GlobalConstants.ENEMY_TAG))
        {
            AudioManager.Instance.PlaySFX("Dead");
        }
    }

    private void Move()
    {
        _currentTime += _isMovingRight ? Time.deltaTime : -Time.deltaTime;

        var progress = Mathf.PingPong(_currentTime, _oneWayTime) / _oneWayTime;
        transform.position = Vector3.Lerp(_leftBorderRange.position, _rightBorderRange.position, progress);
    }


    public void ChangeDirection()
    {
        _isMovingRight = !_isMovingRight;
    }
}
