using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTime : MonoBehaviour
{

    public GameData currentGameData;
    public TextMeshProUGUI timerText;

    private float _timeLeft;
    private float _minutes;
    private float _seconds;
    private float _oneSecondDown;
    private bool _timeOut;
    private bool _stopTimer;
    // Start is called before the first frame update
    void Start()
    {
        _stopTimer = false;
        _timeOut = false;
        _timeLeft = currentGameData.selectedBoardData.timeInSeconds;
        _oneSecondDown = _timeLeft - 1f;

        // Oyun tamamlandığında veya yeni kategori açıldığında zamanlayıcıyı durdurmak için olaylara abone olunuyor.
        GameEvents.OnBoardCompleted += StopTimer;
        GameEvents.OnUnlockNextCategory += StopTimer;

    }


    private void OnDisable()
    {
        GameEvents.OnBoardCompleted -= StopTimer;
        GameEvents.OnUnlockNextCategory -= StopTimer;
    }
    public void StopTimer()
    {
        _stopTimer=true;
    }

     void Update()
    {
        if(_stopTimer==false)
        {
            _timeLeft-= Time.deltaTime;
        }
        if(_timeLeft<=_oneSecondDown)
        {
            _oneSecondDown = _timeLeft - 1f;
        }
    }

    void OnGUI()
    {
        if(_timeOut==false)
        {
            if(_timeLeft > 0)
            {
                _minutes = Mathf.Floor(_timeLeft / 60);
                _seconds=Mathf.RoundToInt(_timeLeft%60);

                timerText.text = _minutes.ToString(format:"00" + ":" +_seconds.ToString(format:"00") );

            }
            else
            {
                _stopTimer = true;
                ActivateGameOverGUI();
            }
        }
    }

    private void ActivateGameOverGUI()
    {
        GameEvents.GameOverMethod();
        _timeOut = true;
    }


}
