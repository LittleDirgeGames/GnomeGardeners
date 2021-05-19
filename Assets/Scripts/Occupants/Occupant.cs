using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace GnomeGardeners
{
	[RequireComponent(typeof(BoxCollider2D))]
	public abstract class Occupant : MonoBehaviour
	{
		public bool multiCellObject = false;
		protected GridCell cell;
		protected List<GridCell> occupantCells;

        #region Unity Methods

        public void Start()
        {
			occupantCells = new List<GridCell>();

			if (multiCellObject)
			{
				BoxCollider2D coll = GetComponent<BoxCollider2D>();

				if(coll.bounds.extents.x >= .4f)
                {
					cell = GameManager.Instance.GridManager.GetClosestCell(new Vector3(transform.position.x + coll.bounds.extents.x, transform.position.y, 0));
					occupantCells.Add(cell);
					cell = GameManager.Instance.GridManager.GetClosestCell(new Vector3(transform.position.x - coll.bounds.extents.x, transform.position.y, 0));
					occupantCells.Add(cell);
				}

				if (coll.bounds.extents.y >= .4f)
				{
					cell = GameManager.Instance.GridManager.GetClosestCell(new Vector3(transform.position.x, transform.position.y + coll.bounds.extents.y, 0));
					occupantCells.Add(cell);
					cell = GameManager.Instance.GridManager.GetClosestCell(new Vector3(transform.position.x, transform.position.y - coll.bounds.extents.y, 0));
					occupantCells.Add(cell);
				}

			}
			else
            {
				cell = GameManager.Instance.GridManager.GetClosestCell(transform.position);
				occupantCells.Add(cell);
				DebugLogger.Log(this, cell.GridPosition.ToString());
			}

			AddOccupantToCells();
		}

		#endregion

		#region Public Methods

		public abstract void Interact(Tool tool);

		#endregion

		#region Protected Methods

		protected void RemoveOccupantFromCells()
        {
			List<GridCell> oldCells = new List<GridCell>();

			foreach (GridCell cell in occupantCells)
            {
				RemoveOccupant(cell);
				oldCells.Add(cell);
			}

			foreach (GridCell cell in oldCells)
				if (occupantCells.Contains(cell))
					occupantCells.Remove(cell);
		}

		protected void AddOccupantToCells(GridCell newCell = null)
		{
			if (newCell != null)
				occupantCells.Add(newCell);

			foreach (GridCell cell in occupantCells)
				AssignOccupant(cell);
		}

		#endregion

		#region Private Methods

		private void AssignOccupant(GridCell cell)
		{
			cell.AddCellOccupant(this);
		}

		private void RemoveOccupant(GridCell cell)
        {
			cell.RemoveCellOccupant();
		}

		#endregion
	}
}
