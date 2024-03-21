using UnityEngine;

public class PatrolBehavior : MonoBehaviour, IBehavior
{
   public void Execute(Enemy enemy) => Debug.Log("Patrol");
}
