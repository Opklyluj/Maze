using UnityEngine;

public class PickUp : MonoBehaviour
{
    public virtual void Picked()
    {
        Debug.Log("Picked");
        Destroy(gameObject);
    }
}