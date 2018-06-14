using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject hexagon;

	void Start () {
        InvokeRepeating("Spawn", 0, 3);
	}
	
    public void Spawn()
    {
        GameObject newHexagon = (GameObject)Instantiate(hexagon) as GameObject;
        newHexagon.transform.position = transform.position;
    }
}
