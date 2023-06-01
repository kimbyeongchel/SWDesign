using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Living
{
    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
    }
}
