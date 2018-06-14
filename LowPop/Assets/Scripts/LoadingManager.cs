using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour {
    [SerializeField] private Image loadingHexagon;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private List<GameObject> listToActive;

    private float time;

	void Start () {
        time = 3f;
        loadingHexagon.GetComponent<Image>().color = Color.red;
        text.SetText("3");
	}
	
	void Update () {
        time -= Time.deltaTime;
        text.SetText("" + (int)time);
        if(time <= 2)
            loadingHexagon.GetComponent<Image>().color = Color.yellow;
        if(time <= 1)
            loadingHexagon.GetComponent<Image>().color = Color.green;
        if (time <= 0)
            Play();
	}

    private void Play()
    {
        loadingPanel.gameObject.SetActive(false);
        foreach (GameObject g in listToActive)
            g.gameObject.SetActive(true);
        Timer.Instance.Reset();
        gameObject.SetActive(false);
    }
}
