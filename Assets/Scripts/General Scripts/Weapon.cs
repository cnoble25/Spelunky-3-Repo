using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    [SerializeField] protected GameObject player;
    protected float damage;

    protected float range;

    protected float attackSpeed;

    public abstract void onHit(GameObject gb);

}
