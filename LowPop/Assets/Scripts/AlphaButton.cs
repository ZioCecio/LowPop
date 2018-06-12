using UnityEngine;
using UnityEngine.UI;

public class AlphaButton : MonoBehaviour {
    public float AlphaThreshold = .1f;

	void Start () {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }
}
