using UnityEngine;

public class MoveImage : MonoBehaviour {
    private int x;
    private int y;
    private float time;

	void Start () {
        x = Random.Range(2, 5);
        y = Random.Range(2, 5);
        time = 10f;

        if (transform.position.y > 0)
            y *= -1;
        if (transform.position.x > 0)
            x *= -1;

        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
	}
	
	void Update () {
        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, 0);
        time -= Time.deltaTime;
        if (time <= 0)
            Destroy(this.gameObject);
	}
}
