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
        Instantiate(
            fencePrefab,
            new Vector3(lanes[Random.Range(0,lanes.Length)],transform.position.y,transform.position.z),//transform.positin is a position of the level chunk
            Quaternion.identity,
            this.transform
        );
    }
  
}
