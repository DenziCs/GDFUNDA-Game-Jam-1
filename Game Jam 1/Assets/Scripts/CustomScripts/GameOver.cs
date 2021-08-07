using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.MP_Events.ON_LOSE_GAME, LoseGame);
    }

    void LoseGame()
    {
        SceneManager.LoadScene("Pink Slip Scene");
    }
}

public class ScoreStorage
{
    public static int score = 0;
}