using UnityEditor.U2D.Animation;
using UnityEngine;

public class CharacterArt : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CharacterSO[] characters;
    [SerializeField] private bool isBot;

    private void Start()
    {
        if(!isBot)
        {
            int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
            CharacterSO selectedCharacter = characters[selectedIndex];
            spriteRenderer.sprite = characters[selectedIndex].characterImage;
        } else
        {
            int randomIndex = Random.Range(0, characters.Length);
            spriteRenderer.sprite = characters[randomIndex].characterImage;
        }
    }
}
