using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected ItemData data;

    [Header("Item Appearance")]
    [SerializeField] protected Color itemColor = Color.antiqueWhite;

    protected virtual void Awake()
    {
        Renderer itemRenderer = GetComponent<Renderer>();

        if (itemRenderer != null)
        {
            itemRenderer.material.color = itemColor;
        }
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

    public abstract void Use(PlayerStats player);

    [Header("ItemMovement")]
    [SerializeField] protected float rotationSpeed = 100f;

    protected virtual void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }


    private bool canClick = true;

    protected virtual void OnMouseDown()
    {
        if (canClick)
        {
            canClick = false;
            StartCoroutine(PulseEffect());
        }    
    }

    private IEnumerator PulseEffect()
    {
        Vector3 originalScale = transform.localScale;
        transform.localScale = originalScale * 1.2f;

        yield return new WaitForSeconds(0.2f);

        transform.localScale = originalScale;
        canClick = true;
    }
}
