using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectXLibrary
{
	public class Coord
	{

		int row;
		int column;

		public Coord(int row, int column) {
			this.row = row;
			this.column = column;
		}

		public int getRow()
		{
			return row;
		}

		public void setRow(int row)
		{
			this.row = row;
		}

		public int getColumn()
		{
			return column;
		}

		public void setColumn(int column)
		{
			this.column = column;
		}

	}
}
