using UnityEngine;

public class RandomEncounter : MonoBehaviour
{
    [SerializeField] private GameObject[] randomEncounterObjects;
    [SerializeField] private GameObject[] treeEncounterObjects;

    public void ChooseRandomEncounter(bool spawnAfterTreeChopped, Vector3 lastPosition)
    {
        if(spawnAfterTreeChopped == false)
        {
            int randomEncounterIndex = Random.Range(0, randomEncounterObjects.Length);
            Instantiate(randomEncounterObjects[randomEncounterIndex], lastPosition, Quaternion.identity);
        } else
        {
            int randomEncounterIndex2 = Random.Range(0, treeEncounterObjects.Length);
            Instantiate(treeEncounterObjects[randomEncounterIndex2], lastPosition, Quaternion.identity);
        }
    }
}
