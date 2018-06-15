using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickHexagon : MonoBehaviour {

	void OnMouseDown()
    {
        GameManager.Instance.Click(System.Convert.ToInt32(this.name));
    }
}
