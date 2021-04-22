using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCommand : ICommand
{
    public void Execute(GridCell cell, Tool tool)
    {
        /* if in front of plant
         *  water plant
         * if in front of pest
         *  add fright to pest
         */

        var plant = cell.Occupant.GameObject.GetComponent<Plant>();
        if (plant != null)
        {
            plant.WaterPlant();
        }

        //var pest = cell.Occupant.GameObject.GetComponent<Pest>();
        //if(pest != null)
        //{
        //    pest.AddFright();
        //}
    }
}
