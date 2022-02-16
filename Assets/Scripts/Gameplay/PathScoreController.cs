using System;
using System.Collections;
using Core;
using Helper;
using Struct;
using UnityEngine;

namespace Gameplay
{
    public class PathScoreController: MonoBehaviour
    {
        private bool isCalc;
        private void OnEnable()
        {
            EventManager.StartListening(EventTypes.GameStart, StartCalc);
            EventManager.StartListening(EventTypes.GameEnd, StopCalc);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventTypes.GameStart, StartCalc);
            EventManager.StopListening(EventTypes.GameEnd, StopCalc);
            StopAllCoroutines();
        }

        private void ResetCalc()
        {
            ScoreController.Instance().ResetScore();
        }

        private void StartCalc()
        {
            isCalc = true;
            ResetCalc();
            StartCoroutine(Calculate());
        }

        private void StopCalc()
        {
            isCalc = false;
            StopAllCoroutines();
        }

        private IEnumerator Calculate()
        {
            while (isCalc)
            {
                ScoreController.Instance().AddScore(1);
                yield return CoroutineHelper.WaitFor(1);
            }
        }
    }
}