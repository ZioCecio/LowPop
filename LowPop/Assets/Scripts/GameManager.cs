using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private GameObject cross;
    [SerializeField] private GameObject check;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TextMeshProUGUI gameOverText;

    public static GameManager Instance;

    private List<int> selectedButtons;
    private List<int> listOfNumbers;
    private int range;
    private int rangeFirst;
    private int rangeSecond;
    private bool wrong;
    private int numberOfButton;
    private int difficulty;
    private bool doNotTouch;
    private bool exclamationMarkActive;
    private bool stop;

    void Awake()
    {
        Instance = this;
    }

	void Start () {
        selectedButtons = new List<int>();
        listOfNumbers = new List<int>();
        range = 20;
        difficulty = LevelManager.Instance.difficulty;
        doNotTouch = false;
        exclamationMarkActive = false;
        stop = false;

        if (difficulty == 0)
        {
            rangeFirst = 0;
            rangeSecond = range;
        }
        if (difficulty == 1)
        {
            rangeFirst = range * -1;
            rangeSecond = range;
        }
        if(difficulty == 2)
        {
            rangeFirst = range * -1;
            rangeSecond = range;
            doNotTouch = true;
        }

        wrong = false;
        numberOfButton = LevelManager.Instance.numberOfHexagones;
        SelectButtons(numberOfButton);
	}
	
	
	void Update () {

        if (Timer.Instance.IsFinished())
        {
            stop = true;
            gameOverText.SetText("Your score is " + ScoreUI.Instance.GetScore() + " points.");
            gameOver.gameObject.SetActive(true);
        }

        if (!AllButtonsHaveBeenClicked())
            return;

        SelectButtons(numberOfButton);
        if (!wrong)
        {
            check.gameObject.SetActive(true);
            ScoreUI.Instance.IncrementScore(numberOfButton);
        }
        wrong = false;
        StartCoroutine(Wait());
    }

    private void SelectButtons(int howMuch)
    {
        int x;

        selectedButtons.Clear();
        listOfNumbers.Clear();
        exclamationMarkActive = false;

        while(selectedButtons.Count < howMuch)
        {
            int num = Random.Range(0, buttons.Count - 1);

            if (!selectedButtons.Contains(num))
            {
                selectedButtons.Add(num);
                buttons[num].gameObject.SetActive(true);
                buttons[num].GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                x = Random.Range(rangeFirst, rangeSecond);

                while(listOfNumbers.Contains(x) || ContainsSeven(x))
                    x = Random.Range(rangeFirst, rangeSecond);

                int r = Random.Range(0, 2);

                if (doNotTouch && selectedButtons.Count == howMuch - 1 && r == 0)
                {
                    x = range + 1;
                    buttons[num].GetComponentInChildren<TextMeshProUGUI>().SetText("!");
                    exclamationMarkActive = true;
                }
                else
                    buttons[num].GetComponentInChildren<TextMeshProUGUI>().SetText("" + x);

                listOfNumbers.Add(x);
            }
        }
    }

    public void Click(int whoClick)
    {
        if (stop)
            return;

        selectedButtons.Remove(whoClick);
        buttons[whoClick].gameObject.SetActive(false);

        if(buttons[whoClick].GetComponentInChildren<TextMeshProUGUI>().GetParsedText().ToCharArray()[0] == '!')
        {
            cross.gameObject.SetActive(true);
            ClearInterface();
            selectedButtons.Clear();
            wrong = true;
            listOfNumbers.Remove(range + 1);
            return;
        }

        int n = System.Convert.ToInt32(buttons[whoClick].GetComponentInChildren<TextMeshProUGUI>().GetParsedText());
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
        if (doNotTouch && exclamationMarkActive && listOfNumbers.Count == 1)
        {
            ClearInterface();
            return true;
        }

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

    public void Restart()
    {
        ClearInterface();
        SelectButtons(numberOfButton);
    }

    private bool ContainsSeven(int num)
    {
        string s = "" + num;
        if (s.Contains("7"))
            return true;
        return false;
    }

    public bool GameIsFinished()
    {
        return stop;
    }
}
