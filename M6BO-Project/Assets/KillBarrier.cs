using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBarrier : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("GameOver");
    }
}
