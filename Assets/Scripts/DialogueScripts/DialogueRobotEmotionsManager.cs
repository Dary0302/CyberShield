using UnityEngine;

namespace DialogueScripts
{
    public class DialogueRobotEmotionsManager : MonoBehaviour
    {
        [SerializeField] private SampleEmotionRobot[] emotionRobots;

        public SampleEmotionRobot GetEmotionRobot(RobotEmotions nameEmotion)
        {
            foreach (var emotionRobot in emotionRobots)
            {
                if (nameEmotion == emotionRobot.EmotionName)
                    return emotionRobot;
            }
            return emotionRobots[^1];
        }
    }
}
