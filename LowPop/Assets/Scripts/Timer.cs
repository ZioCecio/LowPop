using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    [SerializeField] private Image progressBar;

    public static Timer Instance;

    private float maxTime;
    private float timeLeft;

    private bool stop;
    private bool finish;

    void Awake()
    {
        Instance = this;
    }

	void Start () {
        maxTime = 30f;
        timeLeft = maxTime;
        stop = false;
        finish = false;
	}
	
	void Update () {
        if (stop)
            return;

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            progressBar.fillAmount -= 1.0f / maxTime * Time.deltaTime;
        }
        else
        {
            Stop();
            finish = true;
        }
	}

    public void Reset()
    {
        timeLeft = maxTime;
        stop = false;
        finish = false;
    }

    public void Stop()
    {
        stop = true;
    }

    public void Restart()
    {
        stop = false;
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
        progressBar.fillAmount = 1;
    }
}
