using UnityEngine;

public abstract class PickUpCollisionHandler : MonoBehaviour
{
    [SerializeField] string tagName;

    [SerializeField] float rotationSpeed=8f;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName)){
            PickUp();
            Destroy(gameObject);
        }
    }
 
    void Update()
    {
        transform.Rotate(0f,rotationSpeed*Time.deltaTime,0f);
    }

    protected abstract void PickUp();

}
