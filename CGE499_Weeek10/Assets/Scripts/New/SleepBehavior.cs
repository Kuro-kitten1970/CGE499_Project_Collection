using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepBehavior : MonoBehaviour, IBehavior
{
    public void Execute(Enemy enemy) => Debug.Log("Sleep");
}
