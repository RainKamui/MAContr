using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetServer.TcpServer.Protocols
{
    public enum ProtocolType : ushort
    {
		C2SMessage,
		C2SScreenShot,
		C2SCamera,
		C2SDeviceList,
		C2SFileList,
		C2SCommandResult,

		S2CSetScreenShotState,
		S2CSetCameraState,
		S2CSetScreenInterval,
		S2CSetCameraInterval,

		S2CGetDevices,
		S2CGetFileList,
		S2CGetCommandResult,
		S2CRunCSharpCode,
		S2CFileDownload,
		S2CUpdate,
		S2CDownload,

		S2CEventMouseClick,
		S2CEventMouseMove,
		S2CEventKeybord,

		S2CHeartbeat,

    }
}
