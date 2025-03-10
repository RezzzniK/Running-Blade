using System.Collections;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] Transform container;
    int obstcleCount=5;
    float seconds=1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnObstacle());
       
    }
    
    IEnumerator spawnObstacle(){
        
        while (obstcleCount>0)
        {
           yield return new WaitForSeconds(seconds);
           Instantiate(obstacle,transform.position,Quaternion.identity,container);
           obstcleCount--;
        }
        
    }
}
