using System;
using TMPro;
using UnityEngine;

namespace CoinSystem
{
    public class CoinDisplay : MonoBehaviour
    {
        [SerializeField] private CoinService coinService;
        private TextMeshProUGUI _coinsText;
        public void Start()
        {
            _coinsText = GetComponent<TextMeshProUGUI>();
            coinService.OnCoinsCountChange += Show;
        }

        private void OnDisable() => coinService.OnCoinsCountChange -= Show;

        private void Show(int coin) => _coinsText.SetText(coin.ToString());
    }
}
