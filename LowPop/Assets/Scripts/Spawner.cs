using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject hexagon;

	void Start () {
        if(SceneManager.GetActiveScene().name.Equals("Game"))
            InvokeRepeating("Spawn", 0, .5f);
        else
            InvokeRepeating("Spawn", 0, 3);
    }
	
    public void Spawn()
    {
        GameObject newHexagon = (GameObject)Instantiate(hexagon) as GameObject;
        newHexagon.transform.position = transform.position;
    }
}
