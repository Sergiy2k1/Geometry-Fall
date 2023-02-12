using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private SquareSpawner _squareSpawner;

    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _gameOverScreen;

    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _resumepButton;
   

    [SerializeField] private float _gameOverScreenShowDelay; //задержка до появления экрана окончания игры

    private bool _wasGameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }


    private void Update()
    {
        if (_wasGameOver)
        {
            _gameOverScreenShowDelay -= Time.deltaTime;

            if (_gameOverScreenShowDelay <= 0)
            {
                ShowGameOverScreen();
            }
        }
    }
  

    private void ShowGameOverScreen()
    {
        _gameScreen.SetActive(false);
        _gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        var sceneName = SceneManager.GetActiveScene().name; //получаем название сцены
        SceneManager.LoadSceneAsync(sceneName); //загружаем данную сцену
    }
    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseButton()
    {
        AudioManager.Instance.PlaySFX("Button");
        Time.timeScale = 0;
        _pauseButton.SetActive(false);
        _resumepButton.SetActive(true);
    }
    public void ResumeButton()
    {
        AudioManager.Instance.PlaySFX("Button");
        Time.timeScale = 1;
        _pauseButton.SetActive(true);
        _resumepButton.SetActive(false);
    }

    public void OnPlayerDied()
    {
        _wasGameOver = true;
        _squareSpawner.enabled = false;
    }
}
