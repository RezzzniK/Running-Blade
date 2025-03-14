using UnityEngine;

public class PickUpCollisionHandler : MonoBehaviour
{
    [SerializeField] string tagName;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName)){
            //Do smthing
        }
    }
}
