using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinState : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Lecture());
    }
    private IEnumerator Lecture()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
        
    }

}
