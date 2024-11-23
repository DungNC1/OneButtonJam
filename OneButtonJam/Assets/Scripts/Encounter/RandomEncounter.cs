using UnityEngine;

public class RandomEncounter : MonoBehaviour
{
    [SerializeField] private GameObject[] encounterObjects;

    public void ChooseRandomEncounter()
    {
        int randomEncounterIndex = Random.Range(0, encounterObjects.Length);
        Vector3 position = gameObject.transform.position;

        Instantiate(encounterObjects[randomEncounterIndex], position, Quaternion.identity);
    }
}
