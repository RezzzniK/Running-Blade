using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    [SerializeField] GameObject fencePrefab;//reference for fence prefab
    [SerializeField] float [] lanes={-2.5f,0,2.5f};//start pos on X axis of the lanes

    void Start()
    {
        SpawnFence();
    }
    //func for spawn fences
    void SpawnFence(){

        int fencesQuant=Random.Range(1,lanes.Length+1);//generating wich number of the fences
        List <int> availibleLanes=new List<int>{0,1,2};//creating list and populate it with values 0,1,2
        //Debug.Log(fencesQuant);
        while (fencesQuant>0){
            int laneToUse=Random.Range(0,availibleLanes.Count);//getting random value to populate lane with
                                                       //fence
            Instantiate(
                    fencePrefab,
                    new Vector3(
                        lanes[availibleLanes[laneToUse]],//getting lane index from the list and set to start_x list
                        transform.position.y,
                        transform.position.z
                        ),//transform.positin is a position of the level chunk
                    Quaternion.identity,
                    this.transform
            );
            availibleLanes.RemoveAt(laneToUse);//removing element that is under specific index
            fencesQuant--;  
            if (fencesQuant>0 && availibleLanes.Count==0)break;//safe cond 
        }
       


    }
  
}
