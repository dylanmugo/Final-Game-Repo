using UnityEngine;

public class Key : MonoBehaviour
{
    // Add any additional behavior or properties for the key here

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call a method in the ScoreManager or handle key collection here
            CollectKey();
        }
    }

    // Make the method public
    public void CollectKey()
    {
        // Add logic to handle key collection, such as increasing the player's score
        // You might want to disable the key GameObject or play a collection animation
        gameObject.SetActive(false);
    }
}
