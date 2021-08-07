using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkSlipBehavior : MonoBehaviour
{
    private bool isPrinting = true;

    // Update is called once per frame
    void Update()
    {
        if (isPrinting)
        {
            Vector2 currentPos = this.gameObject.transform.localPosition;
            currentPos.y -= 180.0f * Time.deltaTime;
            if (currentPos.y <= 0.0f)
            {
                currentPos.y = 0.0f;
                this.isPrinting = false;
            }
            this.gameObject.transform.localPosition = currentPos;
        }
    }
}