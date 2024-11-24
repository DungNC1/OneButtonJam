using TMPro;
using UnityEngine;

public class TreeChopping : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float chopDelay = 0.3f;
    [SerializeField] private int chopDamage = 1;

    [Header("Components")]
    [SerializeField] private Tree playerTree;
    [SerializeField] private RandomEncounter randomEncounter;

    [Header("Output")]
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
        playerPointsText.text = "Points: " + playerPoints.ToString();

        //Chance of encounter 
        int randomInt = Random.Range(1, 10);

        if (Input.GetKeyDown(KeyCode.Space) && chopDelayCounter <= 0)
        {
            chopDelayCounter = chopDelay;
            playerTree.TakeDamage(chopDamage, this);

            if(randomInt == 1)
            {
                randomEncounter.ChooseRandomEncounter();
            }

            Debug.Log("Chop");
        }
    }
}