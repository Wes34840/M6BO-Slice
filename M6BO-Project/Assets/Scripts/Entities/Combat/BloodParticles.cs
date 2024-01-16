using UnityEngine;

public class BloodParticles : MonoBehaviour
{
    public ParticleSystem bloodParticle;

    void Start()
    {
        bloodParticle = GetComponentInChildren<ParticleSystem>();

    }
    void Update()
    {

        //if()
        //
    }

    public void PlayBloodSpatter()
    {
        bloodParticle.Play();
    }
}
