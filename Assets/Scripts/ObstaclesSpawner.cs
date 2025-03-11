using System.Collections;

using UnityEngine;
using UnityEngine.UIElements;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] GameObject [] obstacles;
    [SerializeField] Transform container;
    [SerializeField] float xClamp=4f;
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
           
           Instantiate(obstacles[Random.Range(0,obstacles.Length)],new Vector3(Random.Range(-xClamp,xClamp),transform.position.y,transform.position.z),Random.rotation/*Quaternion also*/,container);
           obstcleCount--;
        }
        
    }
}
