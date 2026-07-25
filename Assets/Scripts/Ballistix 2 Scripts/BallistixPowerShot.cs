using System.Collections;
using UnityEngine;

public class BallistixPowerShot : MonoBehaviour
{
    [SerializeField] private float activeTime = 0.5f;

    private Collider hitbox;
    private MeshRenderer meshRenderer;
    private bool isActive = false;

    private void Awake()
    {
        hitbox = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();

        hitbox.enabled = false;
        meshRenderer.enabled = false;
    }

    public void Fire()
    {
        if (isActive)
            return;

        StartCoroutine(PowerShotRoutine());
    }

    private IEnumerator PowerShotRoutine()
    {
        isActive = true;

        hitbox.enabled = true;
        meshRenderer.enabled = true;

        yield return new WaitForSeconds(activeTime);

        hitbox.enabled = false;
        meshRenderer.enabled = false;

        isActive = false;
    }

    public bool IsActive()
    {
        return isActive;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            // Handle collision with the player
            Rigidbody ballrb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            ballrb.AddForce(awayFromPlayer * 20, ForceMode.Impulse);
        }

    }
}
