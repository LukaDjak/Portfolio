using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroy : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 30f);
    }
}
