using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    [SerializeField] GameObject fencePrefab;//reference for fence prefab
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float [] lanes={-2.5f,0,2.5f};//start pos on X axis of the lanes
    [SerializeField] int coinsInOneLane=5;
     float spawnChanceApple=.3f;
     float spawnChanceCoin=.5f;
    
     List <int> availibleLanes=new List<int>{0,1,2};//creating list and populate it with values 0,1,2
    

    void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoin();
    }

   void SpawnCoin()
    {
        if (availibleLanes.Count<=0||Random.value>spawnChanceCoin) return;
        int coinsQuant=Random.Range(1,coinsInOneLane+1);
        int laneNum=GetLaneToUse();
       // while(coinsQuant>=0){
        for (int i = 0; i < coinsQuant; i++)
        {
             Instantiate(
                    coinPrefab,
                    new Vector3(
                        lanes[laneNum],//getting lane index from the list and set to start_x list
                        transform.position.y,
                        transform.position.z-5+i*2
                        ),//transform.position is a position of the level chunk
                    Quaternion.identity,
                    this.transform
                );
        }
            
          //  coinsQuant--;
        //}
       
    }

    //func for spawn fences
    void SpawnFence(){

        int fencesQuant=Random.Range(1,lanes.Length);//generating wich number of the fences
       
        while (fencesQuant>0)
        {
            Instantiate(
                    fencePrefab,
                    new Vector3(
                        lanes[GetLaneToUse()/*getting lane to use*/],//getting lane index from the list and set to start_x list
                        transform.position.y,
                        transform.position.z
                        ),//transform.position is a position of the level chunk
                    Quaternion.identity,
                    this.transform
            );
            fencesQuant--;
            if (fencesQuant > 0 && availibleLanes.Count == 0) break;//safe cond 
        }



    }
    

    private int GetLaneToUse()
    {
        int index=Random.Range(0, availibleLanes.Count);
        int lane=availibleLanes[index];
        availibleLanes.RemoveAt(index);//removing element that is under specific index
        return lane;
    }

    void SpawnApple(){
        if (availibleLanes.Count<=0||Random.value>spawnChanceApple) return;
        Instantiate(
                    applePrefab,
                    new Vector3(
                        lanes[GetLaneToUse()],//getting lane index from the list and set to start_x list
                        transform.position.y,
                        transform.position.z
                        ),//transform.position is a position of the level chunk
                    Quaternion.identity,
                    this.transform
        );
       
    }
  
}
