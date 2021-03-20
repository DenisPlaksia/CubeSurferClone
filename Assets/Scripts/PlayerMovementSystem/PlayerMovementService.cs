using System;
using GameSystem;
using InputSystem;
using UnityEngine;

namespace PlayerMovementSystem
{
    public class PlayerMovementService : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private Rigidbody playerRigidbody;
        [SerializeField] private Animator _animator;
        private Vector3 _touchPosition;
        private Vector3 _direction;

        private bool _canMoving = false;
        private const string AnimationName = "IsRunning";
        private void Start()
        {
            InputReaderService.Instance.OnTouchBegin += Moving;
            InputReaderService.Instance.OnTouchEnded += StopMoving;
            GameManager.Instance.OnGameStarted += () => { _canMoving = true; };
            GameManager.Instance.OnGameLose += () =>
            {
                _canMoving = false;
                _animator.SetBool(AnimationName, false);
            };
            GameManager.Instance.OnGameWin += () =>
            {
                _canMoving = false;
                _animator.SetBool(AnimationName, false);
            };
        }

        private void FixedUpdate()
        {
            if (_canMoving)
            {
                _animator.SetBool(AnimationName, true);
                transform.position += new Vector3(0, 0, 2f) * Time.deltaTime;
            }
        }

        private void Moving(Touch touch)
        {
            if (_canMoving)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * moveSpeed * Time.deltaTime,
                    transform.position.y, transform.position.z);
            }
        }
        
        private void StopMoving() => playerRigidbody.velocity = Vector3.zero;
        
        private void OnDisable()
        {
            InputReaderService.Instance.OnTouchBegin -= Moving;
            InputReaderService.Instance.OnTouchEnded -= StopMoving;
        }
    }
}
