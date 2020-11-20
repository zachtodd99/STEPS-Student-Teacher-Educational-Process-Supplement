
using UnityEngine;
using UnityEngine.UI;

public class FadingText : MonoBehaviour{

    public float duration = 1.5f; // time to die
    public float alpha;
    private Text t;


    void Start()
    {
        t = GetComponent<Text>(); 
        t.color = new Color(1f, 0f, 0, 1f); // set text color
        alpha = 1;
    }

    void Update()
    {
        if (alpha > 0)
        {
            
            alpha -= Time.deltaTime / duration;
            t.color = new Color(1f,0f,0,alpha);
        }
        else
        {
            Destroy(gameObject); // text vanished - destroy itself
        }
    }
}