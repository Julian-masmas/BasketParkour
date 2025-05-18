using UnityEngine;

public class damageControl : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private void OnTriggerEnter(Collider other)
    {
        //destination.position.Set(0, 1, 0);
        other.transform.position = destination.position;
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero; 
        }
    }
}
