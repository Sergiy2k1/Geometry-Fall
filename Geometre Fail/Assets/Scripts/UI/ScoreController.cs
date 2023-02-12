using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScoreLabel; //������ �� �����
    [SerializeField] private int _scorePerSquare; //���������� ����� �� ���

    [SerializeField] private float _scaleDuration; //����� ��������� ������
    [SerializeField] private float _scaleFactor; //��������� ��������� ������

    private const string BEST_SCORE = "BestScore"; //��������� ��� ���������� � �������� ������


    private int _bestScore; //������ ��������� �����

    private int _currentScore; //����� ���������� �����

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt(BEST_SCORE);
    }

    public void AddScore()
    {
        _currentScore += _scorePerSquare;

        _currentScoreLabel.text = _currentScore.ToString();
        _currentScoreLabel.transform
                .DOPunchScale(Vector3.one * _scaleFactor, _scaleDuration, 0)
                .OnComplete(() => _currentScoreLabel.transform.DOScale(Vector3.one, 0));
        //���� ��������� ��������� ������� ������ ����� ���������� �� ��� ������������ ������, ������� � ����� �������� ������� ����� ������ 1
    }

    public int GetBestScore()
    {
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
            PlayerPrefs.SetInt(BEST_SCORE, _bestScore); //���������� �������� �� �����
            PlayerPrefs.Save(); //��������� �����
            AudioManager.Instance.PlaySFX("NewBest");
        }

        return _bestScore;
    }

    internal object GetCurrentScore()
    {
        return _currentScore;
    }


}
