using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEngine : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots; // точки для пути
    public int randomSpot, startSpot, nextSpot, endSpot; //случайное перемещение и линейное
    public string walkMode;
    float waitTime; //Ожидание по прибытию к точке
    private float startWaitTime = 0.1f;
    public bool isMove = false;

    void Start()
    {
        transform.position = new Vector2(Random.Range(-3,3),Random.Range(-3,3));
        waitTime = startWaitTime;
        walkMode = "random";
        startSpot = 1;
        nextSpot = Random.Range(startSpot, moveSpots.Length);
        endSpot = 9;
        transform.position = moveSpots[startSpot].position;

    }
    void Update()
    {
        if (isMove == true) 
        {
            EnemyMoveMode("random", startSpot, endSpot);
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);
        }
    }

    void MovePointStep(int startPath, int endPath)
    {       
        if(Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f )
        {               
            if(waitTime<=0)
            {            
                nextSpot +=1;
                if (nextSpot == endPath) nextSpot = startPath;
                waitTime = startWaitTime;
            } 
            else
            {
                waitTime -= Time.deltaTime;    
            }
        }
    }
    void RandomMovePoint(int startPath, int endPath)
    {
        if(Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f )
        {
            if(waitTime<=0)
            {
                nextSpot = Random.Range(startPath, endPath);
                waitTime = startWaitTime;
            } 
            else
            {
                waitTime -= Time.deltaTime;    
            }
        }
    }
    void EnemyMoveMode(string mode, int startPath, int endPath) //String: Line - движение по очереди, random - случайное Int: длинна пути
    {
        switch(mode)
        {
            case "line":
                MovePointStep(startPath, endPath);
            break;
            case "random":
                RandomMovePoint(startPath, endPath);
            break;
        }
        
    }

}
