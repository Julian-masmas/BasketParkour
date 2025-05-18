using UnityEngine;

public class pointControl : MonoBehaviour
{
    public float pointMultiplier;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoint(pointMultiplier);
        }
    }
}
