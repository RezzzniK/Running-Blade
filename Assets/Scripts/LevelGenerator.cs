using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;//prefub object
    [SerializeField] int chunksLenght=10;//lenght of  the chunk array
    [SerializeField] Transform chunkObj;//reference to Parent object where all chunks will be stored in heierarcy
    [SerializeField] float chunkSizeZAxis=10f;
    [SerializeField] float moveChunkSPeed=8f;
    [SerializeField] float speedAmount=2f;
    [SerializeField]float minSpeed=2f;
    [SerializeField] GameObject player;
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
        if (moveChunkSPeed-speedAmount>=minSpeed){
            
            moveChunkSPeed+=speedAmount*speedToAdd;
            camControl.updateCameraFOV((speedAmount+15)*speedToAdd);
            Physics.gravity=new Vector3(Physics.gravity.x,Physics.gravity.y,Physics.gravity.z-/**because we use negativ z axis*/speedAmount*speedToAdd);
        }
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
