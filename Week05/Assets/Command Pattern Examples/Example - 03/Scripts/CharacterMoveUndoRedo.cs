using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveUndoRedo : MonoBehaviour
{
    [SerializeField]
    private List<Move> commandList = new List<Move>();
    public int index;

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
        // Remove any Command between index and the end of the list
        // Clean commandList before ADD more commands while there are still Undo Commands in the list
        if (index < commandList.Count)
            commandList.RemoveRange(index, commandList.Count - index);

        commandList.Add(command as Move);
        command.Execute();
        
        index++;
        UpdateLine();
    }

    public void UndoCommand()
    {
        if (commandList.Count == 0)
            return;

        if (index > 0)
        {
            commandList[index - 1].Undo();                      // BEFORE: commandList[commandList.Count - 1].Undo();
            //commandList.RemoveAt(commandList.Count - 1);      // ** REMOVED ** KEEP Undo command in the list
            index--;                                            // Point index BACKWARD
        }

        UpdateLine();
    }

    public void RedoCommand()
    {
        if (commandList.Count == 0)
            return;

        if (index < commandList.Count)                          // The Previous Command was Undo
        {
            index++;                                            // Point index FOREWARD
            commandList[index - 1].Execute();                   // Execute() the Undo Command
        }

        UpdateLine();
    }

    public void UpdateLine()
    {
        if (pathDrawer == null)
            return;

        List<Vector3> positions = new List<Vector3>();
        positions.Add(startPoint);

        for (int i = 0; i < index; i++)     // Note: i < index, NOT commandList.Count
        {
            Vector3 newPosition = commandList[i].GetMove() + positions[i];
            newPosition.y = verticalOffset; // used to keep it near the ground
            positions.Add(newPosition);
        }

        pathDrawer.UpdateLine(positions);
    }
}
