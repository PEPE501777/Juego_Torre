using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerWinState : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
}
