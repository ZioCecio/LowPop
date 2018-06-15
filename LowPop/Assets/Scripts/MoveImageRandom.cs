using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImageRandom : MonoBehaviour {
    private float x;
    private float y;
    private float time;

    void Start()
    {
        x = Random.Range(2f, 5f);
        y = Random.Range(2f, 5f);
        time = 10f;

        if (transform.position.y > 0)
            y *= -1;
        if (Random.Range(0, 2) == 0)
            x *= -1;

        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    void Update()
    {
        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, 0);
        time -= Time.deltaTime;
        if (time <= 0)
            Destroy(this.gameObject);
    }
}
