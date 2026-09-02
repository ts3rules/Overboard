using UnityEngine;

public class BallistixPlayerSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int spawnerIndex;
    public GameObject prefabPlayer;
    public GameObject prefabAi;

    public GameObject spawner;

    private GameObject player;

    private GameObject ai;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        player = Instantiate(prefabPlayer, spawner.transform.position, spawner.transform.rotation);
    }

    public void SpawnAi()
    {
        ai = Instantiate(prefabAi, spawner.transform.position, spawner.transform.rotation);
    }
}
