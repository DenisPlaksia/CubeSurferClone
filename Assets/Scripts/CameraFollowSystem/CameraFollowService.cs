using System;
using GameSystem;
using UnityEngine;

namespace CameraFollowSystem
{
    public class CameraFollowService : MonoBehaviour
    {
        public Transform player;
        public float speed;
        public Vector3 offset;

        private bool canFollow = false;

        public void Start()
        {
            GameManager.Instance.OnGameStarted += () => canFollow = true;
            GameManager.Instance.OnGameLose += () => canFollow = false;
            GameManager.Instance.OnGameWin += () => canFollow = false;
        }

        public void FixedUpdate()
        {
            if (canFollow)
            {
                Vector3 desiredPosition = player.position + offset;
                Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
                transform.position = smoothPosition;   
            }
        }
    }
}
