using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAfterTime : MonoBehaviour, ISpawnable {

    [SerializeField]
    protected float duration = 1;

    void ISpawnable.Spawn() {
        Callback.FireAndForget(() => SimplePool.Despawn(this.transform.root.gameObject), duration, this);
    }
}
