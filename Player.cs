using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Living
{
    //�� ������Ʈ ��������
    public override void OnEnable()
    {
        base.OnEnable();
        health = 5f;
    }

    public override void Die()
    {
        base.Die();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
