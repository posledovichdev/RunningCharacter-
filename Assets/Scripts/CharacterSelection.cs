using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public void SelectCharacter1()
    {
        // Сохраняем выбранный персонаж в PlayerPrefs для использования в следующей сцене
        PlayerPrefs.SetInt("SelectedCharacter", 1);

        // Загружаем сцену игры
        SceneManager.LoadScene(2);
    }

    public void SelectCharacter2()
    {
        // Сохраняем выбранный персонаж в PlayerPrefs для использования в следующей сцене
        PlayerPrefs.SetInt("SelectedCharacter", 2);

        // Загружаем сцену игры
        SceneManager.LoadScene(2);
    }
}
