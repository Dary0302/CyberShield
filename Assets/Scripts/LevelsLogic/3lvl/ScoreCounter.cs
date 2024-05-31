using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelsLogic._3lvl
{
    public class ScoreCounter : MonoBehaviour
    {
        private readonly int countCorrectNames = FillNames.WrongNames.Length; 
        private readonly HashSet<string> usedNamesHash = new();
        private int score;
        public event Action GameWin;

        public void CheckName(string name)
        {
            if (!usedNamesHash.Add(name))
                return;

            score++;
            if (score == countCorrectNames)
                GameWin?.Invoke();
        }
    }
}
