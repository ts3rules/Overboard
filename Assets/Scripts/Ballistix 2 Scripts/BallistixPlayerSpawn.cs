using UnityEngine;

public class BallistixPlayerSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int spawnerIndex;
    public GameObject prefabPlayer;
    public GameObject prefabAi;

    //goals to be passed to the player/ai prehabs
    public GameObject goal;


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
        BallistixPlayerSetup playerSetup = player.GetComponent<BallistixPlayerSetup>();
        BallistixMovementController movementsetup = player.GetComponent<BallistixMovementController>();
        playerSetup.playerIndex = spawnerIndex;
        movementsetup.playerIndex = spawnerIndex;

    }

    // spawns the Ai and assigns the goal object to it so it knows what to defend
    public void SpawnAi()
    {
        ai = Instantiate(prefabAi, spawner.transform.position, spawner.transform.rotation);
        BallistixAIController aiController =  ai.GetComponent<BallistixAIController>();
        aiController.goal = goal;
        BallistixMovementController movementsetup = ai.GetComponent<BallistixMovementController>();
        movementsetup.playerIndex = spawnerIndex;
    }
}
