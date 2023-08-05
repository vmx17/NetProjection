using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoCAD.Services.Enums
{
    public enum EMouseStatus : uint
    {
        none =      0,
        LeftOn =    0b1,
        MiddleOn =  0b10,
        RightOn =   0b100,
        maxEnum =   0xFFFFFFFF
    }
    public static class MouseStatus
    {
        public static uint GetButtons(bool left, bool middle, bool right)
        {
            uint mouse_button_status = (uint)EMouseStatus.none;
            mouse_button_status |= (uint)(left ? EMouseStatus.LeftOn : EMouseStatus.none);
            mouse_button_status |= (uint)(middle ? EMouseStatus.MiddleOn : EMouseStatus.none);
            mouse_button_status |= (uint)(right ? EMouseStatus.RightOn : EMouseStatus.none);
            return mouse_button_status;
        }
        public static bool IsLeftOn(uint status)
        {
            return (status &= (uint)EMouseStatus.LeftOn) != 0;
        }
        public static bool IsMiddleOn(uint status)
        {
            return (status &= (uint)EMouseStatus.MiddleOn) != 0;
        }
        public static bool IsRightOn(uint status)
        {
            return (status &= (uint)EMouseStatus.RightOn) != 0;
        }
    }
}
