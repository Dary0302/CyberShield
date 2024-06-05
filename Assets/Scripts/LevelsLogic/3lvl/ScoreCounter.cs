using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelsLogic._3lvl
{
    public class ScoreCounter : MonoBehaviour
    {
        private readonly int countWrongNames = FillNames.WrongNames.Length; 
        private readonly HashSet<string> usedNamesHash = new();
        public event Action GameWin;

        public void CheckName(string name)
        {
            if (!usedNamesHash.Add(name))
                return;

            if (usedNamesHash.Count == countWrongNames)
                GameWin?.Invoke();
        }
    }
}
