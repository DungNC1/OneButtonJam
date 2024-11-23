using UnityEngine;

public class Tree : MonoBehaviour
{
    public TreeSO treeType;
    private int health;
    private int reward;

    private void Start()
    {
        health = treeType.health;
        reward = treeType.reward;
    }

    public void TakeDamage(int damage, TreeChopping treeChopping)
    {
        health -= damage;

        if(health < 0)
        {
            treeChopping.playerPoints += reward;
            Destroy(gameObject);
        }
    }
}
