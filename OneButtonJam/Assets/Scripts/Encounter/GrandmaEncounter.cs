using UnityEngine;

public class GrandmaEncounter : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopTime = 3.5f;
    [SerializeField] private float lifetime = 8.5f;

    private GameObject[] players;
    private float stopTimeCounter;
    private int randomSpot;
    private bool destinationReached;

    private void Start()
    {
        stopTimeCounter = stopTime;
        randomSpot = Random.Range(1, 5);
    }

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] bots = GameObject.FindGameObjectsWithTag("Bot");

        players = new GameObject[bots.Length + 1];
        players[0] = player;
        bots.CopyTo(players, 1);
    }


    private void Update()
    {
        if(lifetime >= 0)
        {
            lifetime -= Time.deltaTime;
        } else
        {
            Destroy(gameObject);
        }

        if(destinationReached == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, players[randomSpot].transform.position, speed * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, players[randomSpot].transform.position) < 0.4f)
        {
            destinationReached = true;

            if(stopTimeCounter <= 0)
            {
                players[randomSpot].GetComponent<TreeChopping>().isGrandmaNear = true;
                randomSpot = Random.Range(0, players.Length);
                stopTimeCounter = stopTime;
            } else
            {
                stopTimeCounter -= Time.deltaTime;
            }
        } else
        {
            destinationReached = false;
        }
    }
}
