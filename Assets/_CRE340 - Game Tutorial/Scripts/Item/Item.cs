using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected ItemData data;


    protected virtual void Awake()
    {
        // Come back to this in Part 2
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                Use(playerStats);

                Destroy(this.gameObject);
            }
        }    
    }

    public void DisplayInfo()
    {
        Debug.Log(data.itemName + " : " + data.description);
    }

    public virtual void Use(PlayerStats player)
    {
        Debug.Log("Used a generic item - it did nothing");
    }

    [Header("ItemMovement")]
    [SerializeField] protected float rotationSpeed = 100f;

    protected virtual void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
