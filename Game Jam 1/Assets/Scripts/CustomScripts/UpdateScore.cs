using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private Text scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreDisplay.text = "test";
        this.scoreDisplay.text = ScoreStorage.score.ToString();
    }
}
