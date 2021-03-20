using System;
using UnityEngine;


namespace CoinSystem
{
    public class CoinService : MonoBehaviour
    {
        [SerializeField] private int coins = 0;
        public event Action<int> OnCoinsCountChange; 
        

        public void OnCollisionEnter(Collision other)
        {
            var coin = other.gameObject.GetComponent<Coin>();
            if (coin != null)
            {
                coins++;
                OnCoinsCountChange?.Invoke(coins);
                Destroy(coin.gameObject);
            }
        }
    }
}

