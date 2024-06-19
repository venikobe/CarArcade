using UnityEngine;

public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out CarControll car))
        {
            car._isAlive = false;
         }
    }
}
