using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour {
    [SerializeField] private GameObject pausePanel;

	void OnMouseDown()
    {
        pausePanel.gameObject.SetActive(true);
        Timer.Instance.Stop();
        Debug.Log("CLICCATO");
    }
}
