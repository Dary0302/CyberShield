using UnityEngine;
using UnityEngine.UI;

namespace LevelsLogic
{
    public class StopTimers : MonoBehaviour
    {
        [SerializeField] private GameObject tips;
        [SerializeField] private Button[] pauseTimer;
        [SerializeField] private AbstractTimer[] timers;
        private bool isVisibleTips;

        private void Start()
        {
            foreach (var button in pauseTimer)
            {
                button.onClick.AddListener(PauseTimers);
                button.onClick.AddListener(ShowTips);
            }
        }

        public void PauseTimers()
        {
            foreach (var timer in timers)
            {
                timer.Pause();
            }
        }

        private void ShowTips()
        {
            isVisibleTips = !isVisibleTips;
            tips.SetActive(isVisibleTips);
        }

        private void OnDestroy()
        {
            foreach (var button in pauseTimer)
            {
                button.onClick.RemoveListener(PauseTimers);
                button.onClick.RemoveListener(ShowTips);
            }
        }
    }
}
