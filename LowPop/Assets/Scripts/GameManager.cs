using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] private List<Button> buttons;
    [SerializeField] private GameObject cross;
    [SerializeField] private GameObject check;

    private List<int> selectedButtons;
    private List<int> listOfNumbers;
    private int range;
    private int rangeFirst;
    private int rangeSecond;
    private bool wrong;
    private int numberOfButton;
    private int difficulty;
    private bool doNotTouch;

	void Start () {
        selectedButtons = new List<int>();
        listOfNumbers = new List<int>();
        range = 20;
        difficulty = 0;
        doNotTouch = false;

        if (difficulty == 0)
        {
            rangeFirst = 0;
            rangeSecond = range;
        }
        else if (difficulty == 1)
        {
            rangeFirst = range * -1;
            rangeSecond = range;
        }
        else
        {
            doNotTouch = true;
        }

        wrong = false;
        numberOfButton = 3;
        SelectButtons(numberOfButton);
	}
	
	
	void Update () {
        if (!AllButtonsHaveBeenClicked())
            return;

        SelectButtons(numberOfButton);
        if (!wrong)
        {
            check.gameObject.SetActive(true);
        }
        wrong = false;
        StartCoroutine(Wait());
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
        int n = System.Convert.ToInt32(buttons[whoClick].GetComponentInChildren<Text>().text);
        if (!isLowerNumber(n))
        {
            cross.gameObject.SetActive(true);
            ClearInterface();
            selectedButtons.Clear();
            wrong = true;
        }
        listOfNumbers.Remove(n);
    }

    private bool AllButtonsHaveBeenClicked()
    {
        if (selectedButtons.Count <= 0)
            return true;
        return false;
    }

    private bool isLowerNumber(int n)
    {
        foreach(int i in listOfNumbers)
        {
            if (n > i)
                return false;
        }
        return true;
    }

    private void ClearInterface()
    {
        foreach(int i in selectedButtons)
            buttons[i].gameObject.SetActive(false);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(.2f);
        cross.gameObject.SetActive(false);
        check.gameObject.SetActive(false);
    }
}
