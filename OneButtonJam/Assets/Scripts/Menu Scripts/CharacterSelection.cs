using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
public class CharacterSelection : MonoBehaviour
{
    [Header("Main")]
    public int index; 
    public Sprite[] Characters; 
    public Sprite[] CharacterNames; 
    [SerializeField] private Image charPlaceholder; 
    [SerializeField] private Image charPlaceholderName; 
    [SerializeField] private float fadeDuration = 1f;

    void Update(){
        if(index <= 26 && Input.GetKeyDown(KeyCode.Space)){
            AssignCharacter(index);
            index = index + 1;
        }
        if( index == 26){
            index = 0;
        }
        if (charPlaceholder.sprite != null && charPlaceholderName.sprite != null)
        {
            charPlaceholder.color = Color.white;
            charPlaceholderName.color = Color.white;
        }
    }

    public void AssignCharacter(int index)
    {
        
        if (index >= 0 && index < Characters.Length && index < CharacterNames.Length)
        {
            
            charPlaceholder.sprite = Characters[index];
            charPlaceholderName.sprite = CharacterNames[index];
        }
        else
        {
            Debug.LogWarning("Index is out of bounds for Characters or CharacterNames array!");
        }

        StartCoroutine(FadeIn(charPlaceholder));
        StartCoroutine(FadeIn(charPlaceholderName));
    }

    private IEnumerator FadeIn(Image uiImage)
    {
        if (uiImage == null)
        {
            Debug.LogError("UI Image is not assigned!");
            yield break;
        }

        Color color = uiImage.color;
        float elapsedTime = 0f;

        
        color.a = 0f;
        uiImage.color = color;

       
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration); 
            uiImage.color = color;
            yield return null;
        }

        color.a = 1f;
        uiImage.color = color;
    }
}
