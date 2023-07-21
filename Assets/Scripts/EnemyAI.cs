using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;

// set all walkable things to static
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour, IDamageable 
{
    public GameObject Player;
    [SerializeField] public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public bool IsAlive { get; set; }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        GetComponent<NavMeshAgent>().destination = Player.transform.position;
    }
    
    public void Damage(int damageAmount)
    {
        throw new NotImplementedException();
    }

    public void Heal(int healAmount)
    {
        throw new NotImplementedException();
    }

    public int GetCurrentHealth()
    {
        throw new NotImplementedException();
    }

    public bool Alive()
    {
        throw new NotImplementedException();
    }
}