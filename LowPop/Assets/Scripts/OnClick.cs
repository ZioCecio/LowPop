using UnityEngine;

public class OnClick : MonoBehaviour {
    [SerializeField] private GameObject pausePanel;

	void OnMouseDown()
    {
        if (GameManager.Instance.GameIsFinished())
            return;

        pausePanel.gameObject.SetActive(true);
        Timer.Instance.Stop();
    }
}
