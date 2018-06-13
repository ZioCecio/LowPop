using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int difficulty;
    public int numberOfHexagones;

    public static LevelManager Instance;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

	void Start () {
        difficulty = 0;
        numberOfHexagones = 3;
	}

    public void SelectDifficutly(int num)
    {
        difficulty = num;
    }

    public void SelectNumberOfHexagones(int num)
    {
        numberOfHexagones = num + 3;
    }
}
