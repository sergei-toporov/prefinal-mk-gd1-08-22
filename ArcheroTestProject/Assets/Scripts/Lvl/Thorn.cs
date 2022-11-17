using UnityEngine;

public class Thorn : Obstacles
{
   [SerializeField] private  float _demage;

   public override float Demage => _demage;

   public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Thorn deals damage to player: " + Demage);
        }
    }
}
