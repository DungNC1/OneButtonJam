using TMPro;
using UnityEngine;

public class TreeChopping : MonoBehaviour
{
    [SerializeField] private float chopDelay = 0.3f;
    [SerializeField] private int chopDamage = 1;
    [SerializeField] private Tree playerTree;
    //For Testing
    [SerializeField] private TextMeshProUGUI playerPointsText;

    private float chopDelayCounter;

    [HideInInspector] public int playerPoints;

    private void Start()
    {
        chopDelayCounter = chopDelay;
    }

    private void Update()
    {
        chopDelayCounter -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && chopDelayCounter <= 0)
        {
            chopDelayCounter = chopDelay;
            playerTree.TakeDamage(chopDamage, this);
            playerPointsText.text = "Points: " + playerPoints.ToString();
            Debug.Log("Chop");
        }
    }
}
