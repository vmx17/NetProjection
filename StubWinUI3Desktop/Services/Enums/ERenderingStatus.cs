using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoCAD.Services.Enums
{
	public enum ERenderingStatus : uint
	{
		none =			0b00000000000000000000000000000000,
		MoveMouse =		0b00000000000000000000000000000001,
        MouseUp =		0b00000000000000000000000000000010,
        MouseDown =		0b00000000000000000000000000000100,
		RightButton =	0b00000000000000000000000000001000,
        LeftButton =	0b00000000000000000000000000010000,
        MouseWheel =	0b00000000000000000000000000100000,
        KeyDown =       0b00000000000000000000000001000000,
		KeyUp =			0b00000000000000000000000010000000,
		RubberLine,	// 直線描画中のラバーラインを出す
        RubberArea,	// 領域、グループ、オブジェクトのラバーライン（2本+最小外接矩形）を出す
        RubberCircle,   // 円描画中のラバーライン（円周）を出す
        RubberArc,  // 円弧描画中のラバーライン（円弧）を出す
        RubberElp,  // 楕円描画中のラバーライン（楕円）を出す
        RubberErc,  // 楕円弧描画中のラバーライン（楕円弧）を出す
        RubberSpline,   // スプライン描画中のラバーライン（補助線及び支点類…詳細TBD）を出す
        maxEnum =		0b11111111111111111111111111111111
    }
}
