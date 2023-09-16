using UnityEngine;
using UnityEngine.SceneManagement;

namespace EventArch.Samples
{
    public class EventController : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.AddListener<OnStartGame>(OnStartGame);
            EventManager.AddListener<OnStartGame>(StartGame2);
            EventManager.AddListener<OnFinishGame>(OnFinishGame);
        }

        private void OnDisable()
        {
            EventManager.Clear();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EventManager.Broadcast(Events.onStartGame);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Events.onFinishGame.WinState = true;
                EventManager.Broadcast(Events.onFinishGame);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                EventManager.RemoveListener<OnStartGame>(StartGame2);
            }
        }

        private void OnStartGame(OnStartGame obj)
        {
            Debug.Log("Game started");
        }

        private void StartGame2(OnStartGame obj)
        {
            Debug.Log("Game started 2");
        }

        private void OnFinishGame(OnFinishGame obj)
        {
            SceneManager.LoadScene(0);
            Debug.Log("Game finished " + obj.WinState);
        }

    }
}