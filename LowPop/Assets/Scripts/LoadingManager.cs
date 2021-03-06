﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour {
    [SerializeField] private Image loadingHexagon;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private List<GameObject> listToDisactive;
    [SerializeField] private List<GameObject> listToActive;

    private float time;
    private bool stop;
    private bool change1;
    private bool change2;

	void Start () {
        time = 4f;
        loadingHexagon.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        text.SetText("3");
        stop = false;
        change1 = false;
        change2 = false;
	}
	
	void Update () {
        if (stop)
            return;

        time -= Time.deltaTime;
        text.SetText("" + (int)time);

        if (time <= 3 && !change1)
        {
            loadingHexagon.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            change1 = true;
        }
        if (time <= 2 && !change2)
        {
            loadingHexagon.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            change2 = true;
        }

        if (time <= 1)
            Play();
	}

    private void Play()
    {
        foreach (GameObject g in listToDisactive)
            Destroy(g);

        foreach (GameObject g in listToActive)
            g.gameObject.SetActive(true);

        stop = true;

        if (GameManager.Instance.MOD == 0)
        {
            Stopwatch.Instance.Stop();
            Timer.Instance.ResetBar();
            Timer.Instance.Reset();
        }

        if(GameManager.Instance.MOD == 1)
        {
            Timer.Instance.Stop();
            Stopwatch.Instance.ResetBar();
            Stopwatch.Instance.Reset();
        }
    }
}
