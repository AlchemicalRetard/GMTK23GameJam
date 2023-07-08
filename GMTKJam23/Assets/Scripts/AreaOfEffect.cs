using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour
{
    [SerializeField] int damage = 200;
    [SerializeField] float lifeTime = 0.5f;

    public int GetDamage()
    {
        return damage;
    }

}
