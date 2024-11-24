using UnityEngine;

public class RandomEncounter : MonoBehaviour
{
    [SerializeField] private GameObject[] randomEncounterObjects;
    [SerializeField] private GameObject[] treeEncounterObjects;

    public void ChooseRandomEncounter(bool spawnAfterTreeChopped)
    {
        if(spawnAfterTreeChopped == false)
        {
            int randomEncounterIndex = Random.Range(0, randomEncounterObjects.Length);
            Vector3 position = randomEncounterObjects[randomEncounterIndex].transform.position;

            Instantiate(randomEncounterObjects[randomEncounterIndex], position, Quaternion.identity);
        } else
        {
            int randomEncounterIndex2 = Random.Range(0, treeEncounterObjects.Length);
            Vector3 position = treeEncounterObjects[randomEncounterIndex2].transform.position;

            Instantiate(treeEncounterObjects[randomEncounterIndex2], position, Quaternion.identity);
        }
    }
}
