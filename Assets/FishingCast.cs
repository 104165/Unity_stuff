using UnityEngine;

public class FishingCast : MonoBehaviour
{
    public GameObject bobberPrefab;
    public Transform castPoint;
    public float throwForce = 15f;

    private GameObject currentBobber;

    void Update()
    {
        // Press Spacebar to cast the bobber
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CastBobber();
        }
    }

    void CastBobber()
    {
        // If a bobber already exists, destroy it before casting a new one
        if (currentBobber != null)
        {
            Destroy(currentBobber);
        }

        // Spawn the bobber at the cast point
        currentBobber = Instantiate(bobberPrefab, castPoint.position, castPoint.rotation);

        // Apply force to the bobber's rigidbody to throw it forward and upward
        Rigidbody rb = currentBobber.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 throwDirection = (transform.forward + Vector3.up * 0.5f).normalized;
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }
    }
}