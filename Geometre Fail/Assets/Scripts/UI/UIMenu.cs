using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameStartScreen;
    [SerializeField] private GameObject _gameSettingScreen;
    [SerializeField] private GameObject _gameExitScreen;

    private void Awake()
    {
        _gameStartScreen.SetActive(true);
        _gameSettingScreen.SetActive(false);
    }

    public void StartGame()
    {
        AudioManager.Instance.PlaySFX("Button");
        SceneManager.LoadScene(1);
    }

    public void SettingOpen()
    {
        AudioManager.Instance.PlaySFX("Button");
        _gameStartScreen.SetActive(false);
        _gameSettingScreen.SetActive(true);
    }

    public void OpenMenu()
    {
        AudioManager.Instance.PlaySFX("Button");
        _gameStartScreen.SetActive(true);
        _gameSettingScreen.SetActive(false);
        _gameExitScreen.SetActive(false);
    }
    public void QuestionExitGame()
    {
        AudioManager.Instance.PlaySFX("Button");
        _gameExitScreen.SetActive(true);
        _gameStartScreen.SetActive(false);
    }

    public void ExitGame()
    {
        AudioManager.Instance.PlaySFX("Button");
        Application.Quit();
    }
}
