using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchDestroyBehavior : MonoBehaviour, IBehavior
{
    public void Execute(Enemy enemy) => Debug.Log("Search and Destroy");
}
