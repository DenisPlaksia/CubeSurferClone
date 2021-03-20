using GameSystem;
using UnityEngine;
using UnityEngine.UI;

public class MenuService : MonoBehaviour
{
   [SerializeField] private Button _menu;
   public void Start() => _menu.onClick.AddListener(OnGameBegin);
   private void OnGameBegin() => GameManager.Instance.StartGame();

}
