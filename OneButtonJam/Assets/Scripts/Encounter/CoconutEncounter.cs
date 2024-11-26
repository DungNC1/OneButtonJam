using UnityEngine;

public class CoconutEncounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Stunnable>().ApplyStun();
            Destroy(gameObject);
        }
    }
}
