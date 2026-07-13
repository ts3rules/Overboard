using Unity.VisualScripting;
using UnityEngine;

public class BallistixDetroyObjects : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int lowerBound = -10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }

   
}
