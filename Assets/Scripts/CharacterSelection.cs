using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public void SelectCharacter1()
    {
        // ��������� ��������� �������� � PlayerPrefs ��� ������������� � ��������� �����
        PlayerPrefs.SetInt("SelectedCharacter", 1);

        // ��������� ����� ����
        SceneManager.LoadScene(2);
    }

    public void SelectCharacter2()
    {
        // ��������� ��������� �������� � PlayerPrefs ��� ������������� � ��������� �����
        PlayerPrefs.SetInt("SelectedCharacter", 2);

        // ��������� ����� ����
        SceneManager.LoadScene(2);
    }
}
