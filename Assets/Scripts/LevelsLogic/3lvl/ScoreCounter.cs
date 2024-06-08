using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelsLogic._3lvl
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private FillNames fillNames;
        private int countWrongNames; 
        private readonly HashSet<string> usedNamesHash = new();
        public event Action GameWin;

        private void Start()
        {
            countWrongNames = fillNames.WrongNames.Length;
        }

        public void CheckName(string name)
        {
            if (!usedNamesHash.Add(name))
                return;

            if (usedNamesHash.Count == countWrongNames)
                GameWin?.Invoke();
        }
    }
}
