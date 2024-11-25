using UnityEngine;

public class BotBehaviour : MonoBehaviour
{
    [SerializeField] private TreeChopping treeChopping;

    private void Start()
    {
        InvokeRepeating(nameof(ChopTree), 0.3f, Random.Range(0.3f, 0.7f)); // Bots chop trees every second
    }

    private void ChopTree()
    {
        if (treeChopping.TreeInSight())
        {
            treeChopping.Chop();
        }
    }
}
