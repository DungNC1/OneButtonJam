using UnityEngine;

public class Tree : MonoBehaviour
{
    [Header("Banana")]
    [SerializeField] private GameObject banana;

    public TreeSO treeType;

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
    }

    public void TakeDamage(int damage, TreeChopping treeChopping)
    {
        health -= damage;

        if(health <= 0)
        {
            randomEncounter.ChooseRandomEncounter(true);
            treeChopping.playerPoints += reward;

            //Banana Tree
            if(treeType.name == "BananaTree")
            {
                Instantiate(banana, transform.position, Quaternion.identity);
                Destroy(gameObject);
            } else
            {
                Destroy(gameObject);
            }

        }
    }
}
