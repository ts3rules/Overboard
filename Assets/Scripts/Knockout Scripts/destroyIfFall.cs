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
            if (gameObject.tag == "Player")
            {
               PlayerController playerController = gameObject.GetComponent<PlayerController>();
                AiController aiController = gameObject.GetComponent<AiController>();
                if (playerController != null || aiController != null)
               {
                   if (playerController != null)
                   {
                       playerController.isDead = true;
                   }
                   if (aiController != null)
                   {
                       aiController.isDead = true;
                   }
               }
               



            }
            Destroy(gameObject,0.5f);
        }
    }
}
