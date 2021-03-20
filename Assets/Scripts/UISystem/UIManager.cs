using System;
using GameSystem;
using UnityEngine;

namespace UISystem
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _gamePlayerPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _winPanel;


        public void Start()
        {
            GameManager.Instance.OnGameStarted += () =>
            {
                _menuPanel.SetActive(false);
                _gamePlayerPanel.SetActive(true);
            };
            GameManager.Instance.OnGameLose += () =>
            {
                _gamePlayerPanel.SetActive(false);
                _losePanel.SetActive(true);
            };
            GameManager.Instance.OnGameWin += () =>
            {
                _gamePlayerPanel.SetActive(false);
                _winPanel.SetActive(true);
            };
            
        }
    }
}