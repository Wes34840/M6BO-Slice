using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public EntityStats stats;
    public ComboScript combo;
    void Start()
    {
        stats = GetComponent<EntityStats>();
        combo = GetComponent<ComboScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.health <= 0)
        {
            combo.animator.SetBool("isDead", true);
            combo.GetComponent<ComboScript>().enabled = false;
            StartCoroutine(Delay());

        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("GameOver");
    }
}
