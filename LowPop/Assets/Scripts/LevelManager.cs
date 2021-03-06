﻿using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    [SerializeField] private TMP_Dropdown DifficultyDP;
    [SerializeField] private TMP_Dropdown numberOfHexagonesDP;
    [SerializeField] private TMP_Dropdown ModDP;

    public int difficulty;
    public int numberOfHexagones;
    public int MOD;

    public static LevelManager Instance;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

	void Start () {
        difficulty = 0;
        numberOfHexagones = 3;
        MOD = 0;

        DifficultyDP.value = PlayerPrefs.GetInt("Difficulty");
        DifficultyDP.RefreshShownValue();
        numberOfHexagonesDP.value = PlayerPrefs.GetInt("NumberOfHexagones");
        numberOfHexagonesDP.RefreshShownValue();
        ModDP.value = PlayerPrefs.GetInt("MOD");
        ModDP.RefreshShownValue();
	}

    public void SelectDifficutly(int num)
    {
        difficulty = num;
        PlayerPrefs.SetInt("Difficulty", num);
        DifficultyDP.value = num;
        DifficultyDP.RefreshShownValue();
    }

    public void SelectNumberOfHexagones(int num)
    {
        numberOfHexagones = num + 3;
        PlayerPrefs.SetInt("NumberOfHexagones", num);
        numberOfHexagonesDP.value = num;
        numberOfHexagonesDP.RefreshShownValue();
    }

    public void SelectMOD(int num)
    {
        MOD = num;
        PlayerPrefs.SetInt("MOD", num);
        ModDP.value = num;
        ModDP.RefreshShownValue();
    }
}
