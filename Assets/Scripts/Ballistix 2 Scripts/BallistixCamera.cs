using UnityEngine;

public class BallistixCamera : MonoBehaviour
{
    
    public GameObject Player;
    private Vector3 offset = new Vector3(0, 0.5f, 1.5f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
       transform.position = Player.transform.position + offset;
    }
}
