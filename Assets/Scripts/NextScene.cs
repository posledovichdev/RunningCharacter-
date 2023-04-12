using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int scene = 0;
  public void Transition ()
    {
        SceneManager.LoadScene(scene);
    }
}
