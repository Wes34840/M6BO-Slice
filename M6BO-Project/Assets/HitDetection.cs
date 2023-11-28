using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public ComboScript combo;
    public List<Collider>hits= new List<Collider>();



    private void OnTriggerEnter(Collider other)
    {
        if(combo.isAttacking && other.CompareTag("Enemy") && !hits.Contains(other))
        {
            hits.Add(other);
            Debug.Log("nuts");
        }
    }


}
