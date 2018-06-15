using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour {
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI minuteText;

    public static Stopwatch Instance;

    private float timeLeft;
    private int minute;

    private bool stop;
    private bool finish;

    void Awake()
    {
        Instance = this;
    }

    void Start () {
        timeLeft = 0f;
        minute = 0;

        stop = false;
        finish = false;

        ResetBar();
	}

	void Update () {
        if (stop)
            return;

		if(ScoreUI.Instance.GetScore() >= 50)
        {
            Stop();
            finish = true;
        }

        timeLeft += Time.deltaTime;
        progressBar.fillAmount = timeLeft / 60;

        if(progressBar.fillAmount >= 1) {
            minute++;
            minuteText.SetText("" + minute);
            ResetBar();
            timeLeft = 0f;
        }

	}

    public void Reset()
    {
        timeLeft = 0f;
        stop = false;
        finish = false;
    }

    public void Restart()
    {
        stop = false;
    }

    public void Stop()
    {
        stop = true;
    }

    public bool IsStopped()
    {
        return stop;
    }

    public bool IsFinished()
    {
        return finish;
    }

    public void ResetBar()
    {
        progressBar.fillAmount = 0;
    }

    public int GetTimeSecond()
    {
        return (int)timeLeft;
    }

    public Image GetProgressBar()
    {
        return progressBar;
    }

    public string GetTimeTotal()
    {
        return minute + " minute and " + ((int) (timeLeft / (minute + 1))) + " seconds.";
    }
}
