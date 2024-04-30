using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10;
    private PlayerController playerControllerScript;
    private Animator playerAnima;
    private Vector3 abc;
    // Start is called before the first frame update
    void Start()
    {
        playerAnima = GameObject.Find("Player").GetComponent<Animator>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    playerAnima.SetFloat("Speed_Multiplier", 2);
        //    dash = true;
        //}
        //else if (dash)
        //{
        //    dash = false;
        //    playerAnima.SetFloat("Speed_Multiplier", 1);
        //}

        if (playerControllerScript.gameOver == false)
        {
            if(playerControllerScript.dash)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * 2);
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
        //benim yaptýðým daha güzel oldu:D
        //if(transform.position.y < 0)
        //{
        //    Destroy(gameObject);
        //}
        if(transform.position.x < -15 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
