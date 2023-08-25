using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private CanvasGroup _gamoverGroup;

    private void Start()
    {
        _gamoverGroup = GetComponent<CanvasGroup>();
        _gamoverGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnDied()
    {
        _gamoverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
       SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    
    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
