using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveInstant : MonoBehaviour
{
    [SerializeField]
    private List<Move> commandList = new List<Move>();
    private int index;

    #region path drawing
    //path drawing
    private float verticalOffset = 0.1f;
    private Vector3 startPoint;
    private PathDraw pathDrawer;

    private void Start()
    {
        startPoint = this.transform.position;
        startPoint.y = verticalOffset;
        pathDrawer = this.GetComponent<PathDraw>();
    }
    #endregion

    public void AddCommand(Move command)
    {
        commandList.Add(command);
        command.Execute();                  // Instant Execute()
        
        index++;                            // Used for path drawing
        UpdateLine();
    }

    public void UpdateLine()
    {
        if (pathDrawer == null)
            return;

        List<Vector3> positions = new List<Vector3>();
        positions.Add(startPoint);

        for (int i = 0; i < index; i++)     // Note: i < index
        {
            Vector3 newPosition = commandList[i].GetMove() + positions[i];
            newPosition.y = verticalOffset; // used to keep it near the ground
            positions.Add(newPosition);
        }

        pathDrawer.UpdateLine(positions);
    }
}
