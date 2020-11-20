using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRotate : MonoBehaviour {

    private float speed = 0.01f;
    private float change = 1.0f;
    private bool paused = true;


	// Use this for initialization
	void Update () {
        if (!paused)
        {
            speed += change * 0.01f;

            if (speed >= 1.899f || speed <= 0.0f)
            {
                change = -change;
                speed += change * 0.01f;
            }
            transform.Rotate(new Vector3(0, 0, speed));
        }
	}
	

    public void pauseRotatingTimer()
    {
        if (paused)
        {
            speed = 0.01f;
            change = 1.0f;
            gameObject.transform.eulerAngles = new Vector3(0,0,0);
        }

        paused = !paused;
    }

}
