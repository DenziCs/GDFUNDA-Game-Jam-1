using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDisplay : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text lifeText;
    private int score = 0;
    private int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_CORRECT_MATCH, AddScore);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_WRONG_MATCH, LoseLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        this.score += 100;
        this.scoreText.text = "" + score;
    }

    public void LoseLife()
    {
        this.life--;
        this.lifeText.text = "" + life;
        EventBroadcaster.Instance.PostEvent(EventNames.MP_Events.ON_LOSE_GAME);
    }
}
