using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public Sentence[] sentences;
    
    [System.Serializable]
    public class Sentence
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public string Text { get; private set; }
    }
}