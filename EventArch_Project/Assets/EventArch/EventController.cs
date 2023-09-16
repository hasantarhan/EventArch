using System;
using EventArch.Code;
using UnityEngine;

namespace EventArch
{
    public class EventController : MonoBehaviour
    {
        public void Start()
        {
            EventManager.InitializeEvents();
        }

        private void OnEnable()
        {
            EventManager.AddListener<OnFinishGame>(OnFinishGame2);
        }

        private void OnFinishGame2(OnFinishGame obj)
        {
            obj.WinState;
        }

        private void OnStartGame() 
        {
            Debug.Log("Game strted");
        }
        private void OnFinishGame(bool bln) 
        {
            Debug.Log("Game finished");
        }
    }
}