using TMPro;
using UnityEngine;

public class TreeChopping : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float chopDelay = 0.3f;
    [SerializeField] private int chopDamage = 1;
    [SerializeField] private float range;

    [Header("Components")]
    [SerializeField] private RandomEncounter randomEncounter;
    [SerializeField] private LayerMask treeLayer;

    [Header("Output")]
    [SerializeField] private TextMeshProUGUI playerPointsText; // For player points display

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Bot Settings")]
    public bool isBot = false; // Set true for bots

    private float chopDelayCounter;
    private Tree tree;
    [HideInInspector] public int playerPoints;

    private void Start()
    {
        chopDelayCounter = chopDelay;
    }

    private void Update()
    {
        if (isBot) return; // Skip Update for bots

        chopDelayCounter -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && chopDelayCounter <= 0 && TreeInSight())
        {
            Chop();
        }
    }

    public void Chop()
    {
        chopDelayCounter = chopDelay;

        if (tree != null)
        {
            tree.TakeDamage(chopDamage, this);
        }

        // Trigger random encounter with a small chance
        if (Random.Range(1, 20) == 1 && randomEncounter != null)
        {
            randomEncounter.ChooseRandomEncounter(false, tree.position, gameObject.tag);
        }

        Debug.Log("Chop");
    }

    public bool TreeInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
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
