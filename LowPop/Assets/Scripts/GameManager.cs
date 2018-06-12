using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] private List<Button> buttons;

    private List<int> selectedButtons;
    private List<int> listOfNumbers;
    private int rangeFirst;
    private int rangeSecond;

	void Start () {
        selectedButtons = new List<int>();
        listOfNumbers = new List<int>();
        rangeFirst = 0;
        rangeSecond = 20;
	}
	
	
	void Update () {
        if (!AllButtonsHaveBeenClicked())
            return;

        SelectButtons(3);
	}

    private void SelectButtons(int howMuch)
    {
        int x;
        selectedButtons.Clear();
        listOfNumbers.Clear();
        while(selectedButtons.Count < howMuch)
        {
            int num = Random.Range(0, buttons.Count - 1);
            if (!selectedButtons.Contains(num))
            {
                selectedButtons.Add(num);
                buttons[num].gameObject.SetActive(true);
                buttons[num].GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                x = Random.Range(rangeFirst, rangeSecond);
                while(listOfNumbers.Contains(x))
                    x = Random.Range(rangeFirst, rangeSecond);
                buttons[num].GetComponentInChildren<Text>().text = "" + x;
                listOfNumbers.Add(x);
            }
        }
    }

    public void Click(int whoClick)
    {
        selectedButtons.Remove(whoClick);
        buttons[whoClick].gameObject.SetActive(false);
    }

    public bool AllButtonsHaveBeenClicked()
    {
        if (selectedButtons.Count <= 0)
            return true;
        return false;
    }
}
