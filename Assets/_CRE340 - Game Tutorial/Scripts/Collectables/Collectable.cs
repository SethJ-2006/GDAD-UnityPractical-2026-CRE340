using UnityEditor.Build.Content;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager_Collectathon.instance.IncreaseScore();

            Destroy(this.gameObject);
        }    
    }
}
