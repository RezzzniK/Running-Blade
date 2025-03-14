using UnityEditor.VersionControl;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Destroy(other.gameObject);
    }
}
