using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D BirdBody;
    public float flapStrength = 10;
    public LogicScript logic;
    public bool birdAlive = true;
    public float birdBoundary = 11;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > birdBoundary || transform.position.y < -birdBoundary){
            birdAlive = false;
            logic.gameOver();
        }
        if (Input.GetKeyDown(KeyCode.Space) == true && birdAlive == true){
            BirdBody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        birdAlive = false;
        logic.gameOver();
    }
}
