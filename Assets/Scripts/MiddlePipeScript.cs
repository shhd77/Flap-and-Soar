using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePipeScript : MonoBehaviour
{
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 3){
            logic.AddScore();
        }
    }
}
