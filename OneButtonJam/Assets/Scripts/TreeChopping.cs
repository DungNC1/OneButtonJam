using TMPro;
using UnityEngine;

public class TreeChopping : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float chopDelay = 0.3f;
    [SerializeField] private int chopDamage = 1;
    [SerializeField] private float range;
    [SerializeField] private int maxRapidChops = 5; // Maximum chops allowed within rapidChopResetTime
    [SerializeField] private float rapidChopResetTime = 2f; // Time to reset chop count

    [Header("Components")]
    [SerializeField] private RandomEncounter randomEncounter;
    [SerializeField] private LayerMask treeLayer;
    [SerializeField] private GameObject coconutPrefab; // Assign Coconut prefab

    [Header("Output")]
    [SerializeField] private TextMeshProUGUI playerPointsText;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    private bool isDonated = false;
    private float chopDelayCounter;
    private int coconutChopCount;
    private int grandmaChopCount;
    private float rapidChopTimer;
    private Tree tree;
    private int chopCount;

    [HideInInspector] public bool isChopping;
    [HideInInspector] public int playerPoints;
    [HideInInspector] public bool isGrandmaNear;

    private Stunnable stunnable;

    private void Start()
    {
        chopDelayCounter = chopDelay;
        stunnable = GetComponent<Stunnable>();
        rapidChopTimer = rapidChopResetTime;
    }

    private void Update()
    {
        if (stunnable != null && stunnable.IsStunned()) return;

        chopDelayCounter -= Time.deltaTime;
        rapidChopTimer -= Time.deltaTime;

        if (rapidChopTimer <= 0)
        {
            grandmaChopCount = 0;
            coconutChopCount = 0;
            rapidChopTimer = rapidChopResetTime;
        }
        
        if(isGrandmaNear && grandmaChopCount == 0 && !isDonated)
        {
            playerPoints += 10;
            isDonated = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && chopDelayCounter <= 0 && TreeInSight())
        {
            Chop();
        }

        playerPointsText.text = gameObject.name + playerPoints.ToString();
    }

    public void Chop()
    {
        isChopping = true;

        chopDelayCounter = chopDelay;
        tree.TakeDamage(chopDamage, this);

        int randomInt = Random.Range(0, 50);

        if(randomInt == 1)
        {
            randomEncounter.ChooseRandomEncounter(false, tree.transform.position);
        }

        if (tree.treeType.name == "CoconutTree")
        {
            coconutChopCount++;
            if (coconutChopCount > maxRapidChops)
            {
                SpawnCoconut();
                coconutChopCount = 0;
            }
        }

        if(isGrandmaNear == true)
        {
            grandmaChopCount++;
        } else
        {
            grandmaChopCount = 0;
        }
    }

    private void SpawnCoconut()
    {
        Vector3 coconutSpawnPosition = new Vector3(gameObject.transform.position.x
            , gameObject.transform.position.y + 2f, gameObject.transform.position.z);
        Instantiate(coconutPrefab, coconutSpawnPosition, Quaternion.identity);
        Debug.Log("Coconut fell due to rapid chopping!");
    }

    public bool TreeInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, treeLayer);

        if (hit.collider != null)
        {
            tree = hit.transform.GetComponent<Tree>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
