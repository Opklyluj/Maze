using UnityEngine;

public class Pickup : MonoBehaviour
{
    public virtual void Picked()
    {
        Debug.Log("Picked");
        Destroy(gameObject);
    }
}
