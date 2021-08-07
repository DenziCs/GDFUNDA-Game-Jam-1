using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private Text scoreDisplay;
    [SerializeField] private Text strikeCountDisplay;
    [SerializeField] private Text selectedItemDisplay;

    int currentScore = 0;
    int currentStrikeCount = 3;

    public void UpdateScore(int scoreAddend)
    {
        this.currentScore += scoreAddend;
        this.scoreDisplay.text = currentScore.ToString();
    }

    public void UpdateStrikeCount()
    {
        this.currentStrikeCount -= 1;
        this.strikeCountDisplay.text = currentStrikeCount.ToString();
    }

    public void UpdateSelectedItem(string itemName)
    {
        this.selectedItemDisplay.text = itemName;
    }
}
