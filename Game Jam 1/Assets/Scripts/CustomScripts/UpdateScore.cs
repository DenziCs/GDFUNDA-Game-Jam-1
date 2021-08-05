using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_UPDATE_SCORE, updateScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateScore()
    {
        
    }
}
