using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDisplay : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_CORRECT_MATCH, addScore);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_WRONG_MATCH, subtractScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore()
    {
        this.scoreText.text = "SCORE: TESTADD";
    }

    public void subtractScore()
    {
        this.scoreText.text = "SCORE: TESTSUBTRACT";
    }

    public void OnGiveUp()
    {
        
    }
}
