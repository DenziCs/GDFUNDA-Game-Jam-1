using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
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
        SceneManager.LoadScene("Main Menu");
    }
}
