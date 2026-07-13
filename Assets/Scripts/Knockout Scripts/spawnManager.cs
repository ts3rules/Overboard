using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class spawnManager : MonoBehaviour

{
    int spawnInterval = 5;
    private float spawnPositionZUpper = 7f;
    private float spawnPositionZLower = -12f;
    private float spawnPositionXUpper = 11.4f;
    private float spawnPositionXLower = -7f;
    public GameObject powerUpPrefab;
    private GameObject currentPowerUp;
    private int spawnHeight = 10;
    private bool isSpawning = false;
    private float spawnupper = 10f;
    private float spawnlower = 5f;
    private int floorTimer = 5;
    public Renderer rend;
    public Color flashColor = Color.red;
    private Color originalColor;

    //array of floor objects to choose which one to disapear
    public List<GameObject> floor = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] foundFloors = GameObject.FindGameObjectsWithTag("Floor");

        // 2. Automatically feed those objects into your List
        floor = new List<GameObject>(foundFloors);
        Invoke (nameof(DestroyFloor), floorTimer);

    }

    // Update is called once per frame
    void Update()
    {
         if(currentPowerUp == null && !isSpawning)
        {
            Invoke("SpawnPowerUp", spawnInterval);
            isSpawning = true;
        }
    }

    private void SpawnPowerUp()
    {
      
            float spawnPositionZ = Random.Range(spawnPositionZLower, spawnPositionZUpper);
            float spawnPositionX = Random.Range(spawnPositionXLower, spawnPositionXUpper);
            Vector3 spawnPos = new Vector3(spawnPositionX, spawnHeight, spawnPositionZ);
            
            currentPowerUp = Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
          
            isSpawning = false;
            Invoke("DestroyPowerUp", Random.Range(spawnlower, spawnupper));

    }

    private void OnDrawGizmosSelected()
    {
        // Calculate the center point of your spawn zone
        float centerX = (spawnPositionXUpper + spawnPositionXLower) / 2f;
        float centerZ = (spawnPositionZUpper + spawnPositionZLower) / 2f;
        Vector3 center = new Vector3(centerX, 0.5f, centerZ);

        // Calculate the total size
        float sizeX = spawnPositionXUpper - spawnPositionXLower;
        float sizeZ = spawnPositionZUpper - spawnPositionZLower;
        Vector3 size = new Vector3(sizeX, 1f, sizeZ);

        // Draw a green wireframe box in the Scene view
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(center, size);
    }

    private void DestroyPowerUp()
    {
        Destroy(currentPowerUp);
    }

    private void DestroyFloor()
    {
        if (floor.Count == 0) return;

        int floorIndex = Random.Range(0, floor.Count);

        GameObject selectedFloor = floor[floorIndex];

        StartCoroutine(DoFlash(selectedFloor, floorIndex));
    }

    public void FlashFloor()
    {
        
        StartCoroutine("DoFlash");

    }

    private IEnumerator DoFlash(GameObject floorTile, int floorIndex)
    {
        Renderer rend = floorTile.GetComponent<Renderer>();

        Color originalColor = rend.material.color;

        rend.material.color = flashColor;

        yield return new WaitForSeconds(0.5f);

        rend.material.color = originalColor;

        floorTile.SetActive(false);

        floor.RemoveAt(floorIndex);

        Invoke(nameof(DestroyFloor), 1f);
    }

}
