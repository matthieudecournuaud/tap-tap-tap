using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    // Start is called before the first frame update
    public void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }

}
