using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;//prefub object
    [SerializeField] int chunksLenght=10;//lenght of  the chunk array
    [SerializeField] Transform chunkObj;//reference to Parent object where all chunks will be stored in heierarcy
    [SerializeField] float chunkZlenght=10f;
    [SerializeField] float moveChunkSPeed=8f;
    // GameObject [] chunksArr;
    List <GameObject> chunksList;
    void Start()
    {
       // chunksArr=new GameObject[chunksLenght];//initiateing lenght of chunk array
       chunksList=new List<GameObject>();
        SpawnChunks();
    }

    private void SpawnChunks()
    {
        Vector3 pos = transform.position;
        for (int i = 0; i < chunksLenght; i++)
        {
            // chunksArr[i]=Instantiate(chunkPrefab, pos, Quaternion.identity, chunkObj);//getting reference of instantiated element to the array
           chunksList.Add(Instantiate(chunkPrefab, pos, Quaternion.identity, chunkObj));
            pos.z += chunkZlenght;
        }
    }
    void Update()
    {
        MoveChunks();
    }
    void MoveChunks(){
        #region old
        // Vector3 pos = transform.position;
        // for (int i = 0; i < chunksLenght; i++)
        // {
        //     //chunksArr[i].gameObject.transform.Translate(0,0,-moveChunkSPeed*Time.deltaTime);//moving each chunk
        //     chunksArr[i].gameObject.transform.Translate(transform.forward*(-moveChunkSPeed*Time.deltaTime));

        // }
        #endregion
        // foreach (var chunk in chunksArr)
        // {
        //     chunk.transform.Translate(transform.forward*(-moveChunkSPeed*Time.deltaTime));
        // }
        foreach (var chunk in chunksList)
        {
             chunk.transform.Translate(transform.forward*(-moveChunkSPeed*Time.deltaTime));
        }
    }

    
}
