using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator sceneTransitionAnim;
    public float transitionTime = 2f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        sceneTransitionAnim.SetTrigger("Loaded");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);   
    }
}
