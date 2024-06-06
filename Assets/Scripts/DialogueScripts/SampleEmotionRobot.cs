using UnityEngine;

namespace DialogueScripts
{
    [CreateAssetMenu(fileName = "New Emotion Robot", menuName = "Emotion Robot")]
    public class SampleEmotionRobot : ScriptableObject
    {
        [field: SerializeField] public RobotEmotions EmotionName { get; private set; }
        [field: SerializeField] public Sprite FaceEmotion { get; private set; }
    }
}