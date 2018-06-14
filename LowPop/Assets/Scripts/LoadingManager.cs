using System.Collections;
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
        time = 3f;
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

        if ((int)time == 2 && !change1)
        {
            loadingHexagon.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            change1 = true;
        }
        if ((int)time == 1 && !change2)
        {
            loadingHexagon.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            change2 = true;
        }

        if (time <= 0)
            Play();
	}

    private void Play()
    {
        foreach (GameObject g in listToDisactive)
            Destroy(g);

        foreach (GameObject g in listToActive)
            g.gameObject.SetActive(true);

        stop = true;
        Timer.Instance.ResetBar();
        Timer.Instance.Reset();
    }
}
