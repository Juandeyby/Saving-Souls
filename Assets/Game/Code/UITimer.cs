using System.Collections;
using TMPro;
using UnityEngine;

namespace Game.Code
{
    public class UITimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text timer;
        private int _currentTime;
        private Coroutine _countingRoutine;

        public void StartTimer()
        {
            _currentTime = 0;
            _countingRoutine = StartCoroutine(CountingRoutine());
        }

        public void StopTimer()
        {
            StopCoroutine(_countingRoutine);
        }

        private IEnumerator CountingRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                _currentTime++;
                SetText();
            }
        }

        private void SetText()
        {
            timer.text = _currentTime.ToString("0:00");
        }
    }
}
