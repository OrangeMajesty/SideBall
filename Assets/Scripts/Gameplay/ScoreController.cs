using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class ScoreController: MonoBehaviour
    {
        private int _currentScore;
        private int _appendScore;
        [SerializeField]
        private Text _text;
        
        private static ScoreController _instance;

        public static ScoreController Instance()
        {
            if (_instance == null)
                throw new Exception("ScoreController not found");
            return _instance;
        }

        private void Awake()
        {
            _instance = this;
            UpdateText();
        }

        public void AddScore(float score)
        {
            _appendScore += (int)score;
            UpdateText();
        }
        
        public void SetScore(float score)
        {
            _currentScore = (int)score;
            UpdateText();
        }

        public void ResetScore()
        {
            _currentScore = 0;
            _appendScore = 0;

            UpdateText();
        }

        public int GetScore()
        {
            return _currentScore + _appendScore;
        }

        private void UpdateText()
        {
            if (_text)
                _text.text = GetScore().ToString();
        }
    }
}