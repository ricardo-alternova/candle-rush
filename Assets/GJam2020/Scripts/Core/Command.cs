using System.Collections.Generic;
using GJam2020.Avatar;
using UnityEngine;

namespace GJam2020.Core
{
    public abstract class Command
    {
        public Command ReverseCommand { get; set; }

        //Move and save command
        public abstract void Execute(PlayerMovement playerMovement, bool needToBeSaved);

        //Undo an old command
        public abstract void Undo(PlayerMovement playerMovement);

        public bool isExecuting;

        protected void OnExecutionComplete()
        {
            isExecuting = false;
        }

    }

    public class MoveForward : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved)
        {
            isExecuting = true;
            //Move the box
            playerMovement.Move(MovementDirection.Forward, OnExecutionComplete);

            //Save the command
            if (!needToBeSaved) return;
            CommandsManager.AddCommand(this);
        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement)
        {
            Debug.Log("Undoing");
            ReverseCommand.Execute(playerMovement, false);
            CommandsManager.RemoveLastCommand();
        }
    }

    public class MoveBackward : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved)
        {
            isExecuting = true;
            //Move the box
            playerMovement.Move(MovementDirection.Backward, OnExecutionComplete);

            //Save the command
            if (!needToBeSaved) return;
            CommandsManager.AddCommand(this);
        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement)
        {
            Debug.Log("Undoing");
            ReverseCommand.Execute(playerMovement, false);
            CommandsManager.RemoveLastCommand();
        }
    }

    public class MoveLeft : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved)
        {
            isExecuting = true;
            //Move the box
            playerMovement.Move(MovementDirection.Left, OnExecutionComplete);

            //Save the command
            if (!needToBeSaved) return;
            CommandsManager.AddCommand(this);
        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement)
        {
            Debug.Log("Undoing");
            ReverseCommand.Execute(playerMovement, false);
            CommandsManager.RemoveLastCommand();
        }
    }

    public class MoveRight : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved)
        {
            isExecuting = true;
            //Move the box
            playerMovement.Move(MovementDirection.Right, OnExecutionComplete);

            //Save the command
            if (!needToBeSaved) return;
            CommandsManager.AddCommand(this);
        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement)
        {
            Debug.Log("Undoing");
            ReverseCommand.Execute(playerMovement, false);
            CommandsManager.RemoveLastCommand();
        }
    }
}
