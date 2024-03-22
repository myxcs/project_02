using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    public bool showed;

    private void OnBecameVisible()
    {
        showed = true;
        print("show");
    }

    private void OnBecameInvisible()
    {
        if (showed)
        {
            print("die");
            Destroy(gameObject);
        }
    }
}
