using UnityEngine;

public class Tree : MonoBehaviour
{
    [Header("Banana")]
    [SerializeField] private GameObject banana;

    public TreeSO treeType;
    [HideInInspector] public Vector3 position;

    private RandomEncounter randomEncounter;

    private int health;
    private int reward;

    private void Awake()
    {
        randomEncounter = GameObject.FindWithTag("GameManager").GetComponent<RandomEncounter>();
    }

    private void Start()
    {
        health = treeType.health;
        reward = treeType.reward;
        position = transform.position;
    }

    public void TakeDamage(int damage, TreeChopping treeChopping)
    {
        health -= damage;

        if (health <= 0)
        {
            randomEncounter.ChooseRandomEncounter(true, position, gameObject.tag);
            treeChopping.playerPoints += reward;

            if (treeType.name == "BananaTree")
            {
                Instantiate(banana, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
