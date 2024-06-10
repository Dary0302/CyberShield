using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public Sentence[] sentences;
    
    [System.Serializable]
    public class Sentence
    {
        [field:SerializeField] public Names Name { get; private set; }
        [field:SerializeField] public RobotEmotions RobotEmotion { get; private set; }
        [field:SerializeField] public string Text { get; private set; }
    }
}

public enum Names
{
    Robot,
    GG
}

public enum RobotEmotions
{
    Joy,
    Sad,
    Shock,
    Shy,
    Stupid,
    Empty
}