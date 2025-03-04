using dotNetLab.Common;
using dotNetLab.Data.Network;
using dotNetLab.Data.Uniting;
using System.IO.Ports;

namespace shikii.VisionJob
{
	public class AddressPLCEx : AddressPLC
	{
		private UnitDB CompactDB = null;

		public AddressPLCEx(string TableName = "SerialPort")
		{
			InitArgs(TableName);
		}

		public AddressPLCEx()
		{
		}

		public void InitArgs(string TableName = "SerialPort")
		{
			CompactDB = R.CompactDB;
			CompactDB.TargetTable = TableName;
			base.PortName = CompactDB.FetchValue("COM", true, "0");
			base.Parity = (Parity)CompactDB.FetchIntValue("Parity");
			base.StopBits = (StopBits)CompactDB.FetchIntValue("StopBits");
			base.BaudRate = CompactDB.FetchIntValue("BaudRate");
			base.DataBits = CompactDB.FetchIntValue("DataBits");
			base.BufferSize = 128;
			CompactDB.TargetTable = CompactDB.DefaultTable;
		}
	}
}
