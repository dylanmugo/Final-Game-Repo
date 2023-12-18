using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int keyID = 1; // Assign a unique ID to each key
    public AudioClip collectSound; // Sound to play when a key is collected

    // This method is called when the player collides with the key
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the player already has this key (based on keyID)
            if (!KeyManager.Instance.HasKey(keyID))
            {
                // Add the key to the player's key collection
                KeyManager.Instance.AddKey(keyID);

                // Play a sound or particle effect if desired
                PlayCollectEffect();

                // Disable the key (assuming you want to deactivate it after collecting)
                gameObject.SetActive(false);
            }
        }
    }

    void PlayCollectEffect()
    {
        // Implement code to play a sound or particle effect when a key is collected
        // Example: Instantiate a particle effect or play a sound
        // Example: GetComponent<AudioSource>().PlayOneShot(collectSound);
    }
}
