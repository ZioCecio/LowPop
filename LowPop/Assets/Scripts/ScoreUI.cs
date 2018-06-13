using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI text;

    private int score;

    public static ScoreUI Instance;

    void Awake()
    {
        Instance = this;
    }

	void Start () {
        score = 0;
        text.SetText("SCORE: " + score);
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        text.SetText("SCORE: " + score);
    }

    public int GetScore()
    {
        return score;
    }
}
