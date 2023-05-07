using System;

// this controls corresponds to the ps4 controller but xbox could be the same
public enum EControlType { NONE, SQUARE, CROSS, TRIANGLE, CIRCLE, UP, DOWN, RIGHT, LEFT }

[System.Serializable]
public struct ControlInput
{
    public EControlType control;
    public bool isCompleted;
}

[System.Serializable]
public class ButtonsSequence
{
    public EControlType[] buttonSequence;
    public bool sequenceCompleted;
    
    public EControlType currentLoopControl;

   public void NextLoopControl()
   {
       for (int i = 0; i < buttonSequence.Length - 1; i++)
       {
           if (buttonSequence[i + 1] != null)
           {
               currentLoopControl = buttonSequence[i + 1];
               break;
           }
       }
   }
   
   public void NextLoopControl(int index)
   {
       currentLoopControl = buttonSequence[index];
   }
   
   public void SetInitControl()
   {
       currentLoopControl = buttonSequence[0];
   }
}
