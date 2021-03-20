using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UISystem
{
    public class RestartGameButton : MonoBehaviour
    {
        [SerializeField] private Button _restartGame;

        public void Start()
        {
            _restartGame = GetComponent<Button>();
            _restartGame.onClick.AddListener(Restart);
        }

        private void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}