using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator birdAnimator;
    public LogicScript logic;
    public AudioSource flySound;
    public AudioSource crashSound;
    public AudioSource fallSound;
    bool hasFallen = false;

    float topBound;
    float bottomBound;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        topBound = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        bottomBound = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true){
            rb.velocity = Vector2.up * 5;
            birdAnimator.SetTrigger("Fly");
            flySound.Play();
        }

        if (transform.position.y > topBound || transform.position.y < bottomBound)
        {
            if (!hasFallen){
                hasFallen = true;
                fallSound.Play();
                logic.GameOver();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision){
            crashSound.Play();
            logic.GameOver();
    }
}

