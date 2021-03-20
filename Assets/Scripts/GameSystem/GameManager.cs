using System;
using UnityEngine;

namespace GameSystem
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public event Action OnGameStarted;
        public event Action OnGameLose;
        public event Action OnGameWin; 
        private void Awake() => Instance = this;

        public void StartGame() => OnGameStarted?.Invoke(); 

        public void LoseGame() => OnGameLose?.Invoke();

        public void WinGame() => OnGameWin?.Invoke();
    }
}