using UnityEngine;

public class BananaEncounter : MonoBehaviour
{
    [SerializeField] private float bananaSpeed = 5f;

    private Transform targetTransform;
    private GameObject[] botsTransform;
    private float distance;


    private void Awake()
    {
        botsTransform = GameObject.FindGameObjectsWithTag("Bot");
        int randomPlayerIndex = Random.Range(1, botsTransform.Length);
        targetTransform = botsTransform[randomPlayerIndex].transform;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, targetTransform.position);
        Vector2 direction = targetTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, bananaSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
