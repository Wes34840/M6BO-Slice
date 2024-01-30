using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityDeath : MonoBehaviour
{
    private EntityStats _entityStats;
    private ComboScript _comboScript;
    [SerializeField] private Animator _anim;

    void Start()
    {
        TryGetComponent<EntityStats>(out _entityStats);
        TryGetComponent<ComboScript>(out _comboScript);
    }

    // Update is called once per frame
    void Update()
    {
        if (_entityStats.health <= 0)
        {
            _anim.SetBool("IsDead", true);
            if (_comboScript != null)
            {
                _comboScript.enabled = false;
                StartCoroutine(WaitForDelay());
            }

        }

    }

    private IEnumerator WaitForDelay()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("GameOver");
    }

}
