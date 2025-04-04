using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject chunkPrefab;//prefub object
    [SerializeField] Transform chunkObj;//reference to Parent object where all chunks will be stored in heierarcy
    [Header("Level Settings")]
    [SerializeField] int chunksLenght=10;//lenght of  the chunk array
    [Tooltip("Do not change the size of the chunk, unless chunk prefab size refleects the changee")]
    [SerializeField] float chunkSizeZAxis=10f;
    [SerializeField] float moveChunkSPeed=8f;
    [SerializeField] float speedAmount=2f;
    [SerializeField]float minSpeed=5f;
    [SerializeField]float maxSpeed=20f;
    [SerializeField]float minGravityZpeed=-2f;
    [SerializeField]float maxGravityZpeed=-22f;
    CameraControler camControl;

    List <GameObject> chunksList;
    void Start()
    {
       chunksList=new List<GameObject>();
       SpawnChunks();
       camControl=FindFirstObjectByType<CameraControler>();
    }

    private void SpawnChunks()
    {
        Vector3 pos = transform.position;
        for (int i = 0; i < chunksLenght; i++)
        {
        
           chunksList.Add(Instantiate(chunkPrefab, pos, Quaternion.identity, chunkObj));
            pos.z += chunkSizeZAxis;
        }
    }
    void Update()
    {
        MoveChunks();

    }
    public void ChangeLevelSpeed(float speedToAdd/**will be -1 or 1 depending on which obstcle we picked up*/)
    {
        moveChunkSPeed=Mathf.Clamp(moveChunkSPeed+speedToAdd, minSpeed, maxSpeed);
        //if (moveChunkSPeed-speedAmount>=minSpeed){
       // moveChunkSPeed+=speedAmount*speedToAdd;
        camControl.updateCameraFOV((speedAmount+15)*speedToAdd);
        Physics.gravity=new Vector3(Physics.gravity.x,
                                    Physics.gravity.y,
                                    Mathf.Clamp(Physics.gravity.z+/**because we use negativ z axis*/speedAmount*speedToAdd,minGravityZpeed,maxGravityZpeed)
                                    );
       // }
    }
    void MoveChunks(){
        for (int i = 0; i < chunksList.Count; i++)
        {
            if (chunksList[i].gameObject.activeInHierarchy){


              chunksList[i].transform.Translate(transform.forward*(-moveChunkSPeed*Time.deltaTime));

            }

            //check if it pass the camera position
            GameObject chunk= chunksList[i];
            if (chunk.transform.position.z<Camera.main.transform.position.z-chunkSizeZAxis/*adding a bit more distance to make it disapear less noticble*/){
                //hide chunk
                chunk.SetActive(false);
                //set chunk first in row
                chunk.transform.Translate(0,0,chunksList.Count*chunkSizeZAxis);
                //show chunk
                chunk.SetActive(true);
            }            
        }
    }    
}
