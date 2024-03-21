using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveTurnBased : MonoBehaviour
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

    public void AddCommand(ICommand command)
    {
        commandList.Add(command as Move);
        //command.Execute();                    // *** Remove from here *** Will be Execute() later
        
        //index++;                              // *** Remove from here *** Will be increse after Execute() later
        //UpdateLine();                         // *** Remove from here *** Will be UpdateLine() later
    }

    public void DoMoves()
    {
        StartCoroutine(DoMovesOverTime());
    }

    private IEnumerator DoMovesOverTime()
    {   
        int startIndex = index;

        for (int i = startIndex; i < commandList.Count; i++)
        {
            commandList[i].Execute();
            
            index++;
            UpdateLine();

            yield return new WaitForSeconds(0.5f);
        }
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

