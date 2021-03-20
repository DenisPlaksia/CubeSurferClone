using System;
using UnityEngine;

namespace InputSystem
{
    public class InputReaderService : MonoBehaviour
    {
        public static InputReaderService Instance { get; private set; }
        public event Action<Touch> OnTouchBegin;
        public event Action OnTouchEnded; 
        private void Awake() => Instance = this;

        public void Update()
        {
            if (Input.touchCount > 0)
            {         
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    OnTouchBegin?.Invoke(touch);
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    OnTouchEnded?.Invoke();
                }
            }
        }
    }
}