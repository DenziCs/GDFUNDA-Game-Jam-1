using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject pinkSlip;
    [SerializeField] private Text finalScoreDisplay;

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
        this.pinkSlip.SetActive(true);
        // this.finalScoreDisplay.text = this.currentScore.ToString();
        SceneManager.LoadScene("Main Menu");
    }
}
