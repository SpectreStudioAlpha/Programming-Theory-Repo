using UnityEngine;

public class ManagerUnit : Unit //inherits from Unit 
{
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;
    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;
 
           if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }

     }

 //   private void ResetProductivity()
 //   {
 //       if (m_CurrentPile != null)
 //       {
 //           m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
 //           m_CurrentPile = null;
 //       }
 //   }

    public override void GoTo(Building target) //abstract method from Unit class
    {
        base.GoTo(target);
        //ResetProductivity();
    }

    public override void GoTo(Vector3 position) //abstract method from Unit class
    {
        //ResetProductivity();
        base.GoTo(position);
    }



}
