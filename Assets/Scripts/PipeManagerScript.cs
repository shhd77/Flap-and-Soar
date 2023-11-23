using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManagerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate;
    private float timer = 0;
    private float heightOffset = 2.9f;
    public int currentLevel = 1;

    void Start(){
        spawnPipe();
    }

    void Update(){
        if(timer < spawnRate){
            timer += Time.deltaTime;
        } else {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        GameObject newPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

        pipeMove pipeMovement = newPipe.GetComponent<pipeMove>();
        if (pipeMovement != null)
        {
            pipeMovement.speed = CalculateSpeed();
        }
    }

    float CalculateSpeed()
    {
        return 5f + currentLevel * 2f;
    }
}
