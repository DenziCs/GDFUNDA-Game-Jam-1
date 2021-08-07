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
    private bool isOver = false;
    private bool isPrinting = false;

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.MP_Events.ON_LOSE_GAME, LoseGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPrinting)
        {
            Vector2 currentPos = this.pinkSlip.transform.localPosition;
            currentPos.y -= 100.0f * Time.deltaTime;
            if (currentPos.y <= 0.0f)
            {
                currentPos.y = 0.0f;
                this.isPrinting = false;
            }
            this.pinkSlip.transform.localPosition = currentPos;
        }
    }

    void LoseGame()
    {
        this.isOver = true;
        this.score = this.GetComponentInParent<UpdateUI>().currentScore;
        this.pinkSlip.SetActive(true);
        this.finalScoreDisplay.text = this.score.ToString();
        this.isPrinting = true;
    }
}
