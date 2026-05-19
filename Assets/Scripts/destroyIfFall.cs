using UnityEngine;

public class destroyIfFall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int destroyHeight = -20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}
