using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject pinkSlip;
    [SerializeField] private Text finalScoreDisplay;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.MP_Events.ON_LOSE_GAME, LoseGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoseGame()
    {
<<<<<<< HEAD
        score = this.GetComponent<UpdateUI>().currentScore;
        this.pinkSlip.SetActive(true);
        this.finalScoreDisplay.text = this.score.ToString();
=======
        this.pinkSlip.SetActive(true);
        // this.finalScoreDisplay.text = this.currentScore.ToString();
        SceneManager.LoadScene("Main Menu");
>>>>>>> parent of 924f1c6 (Updated the GameOver script to animate the pink slip.)
    }
}
