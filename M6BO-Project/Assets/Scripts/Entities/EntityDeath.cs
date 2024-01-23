using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityDeath : MonoBehaviour
{
    public EntityStats entityStats;
    public ComboScript comboScript;

    void Start()
    {
        entityStats = GetComponent<EntityStats>();
        comboScript = GetComponent<ComboScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (entityStats.health <= 0)
        {
            comboScript.anim.SetBool("isDead", true);
            comboScript.GetComponent<ComboScript>().enabled = false;
            StartCoroutine(WaitForDelay());
        }

    }

    private IEnumerator WaitForDelay()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("GameOver");
    }

}
