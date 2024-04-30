using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    private PlayerController playercontrollerscript;
    // Start is called before the first frame update
    void Start()
    {
        playercontrollerscript=GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontrollerscript.dash && !playercontrollerscript.gameOver)
        {
            score = +2;
        }
        else if(!playercontrollerscript.dash && !playercontrollerscript.gameOver)
        {
            score ++;
        }
        Debug.Log("Score is " + score);
    }
}
