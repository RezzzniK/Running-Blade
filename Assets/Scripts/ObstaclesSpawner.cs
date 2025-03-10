using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] Transform container;
    int obstcleCount=5;
     [SerializeField] float spawnTime=1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnObstacle());
       
    }
    
    IEnumerator spawnObstacle(){
        
        while (/*obstcleCount>0*/true)
        {
           yield return new WaitForSeconds(spawnTime);
           //Instantiate(obstacle,transform.position,Quaternion.identity,container);
           Instantiate(obstacle,transform.position,Random.rotation/*Quaternion also*/);
           obstcleCount--;
        }
        
    }
}
