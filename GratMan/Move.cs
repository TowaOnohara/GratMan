using System;
using System.Collections;
using Microsoft.SPOT;

namespace GratMan
{
    //━━━━━━━━━━━━━━━━━━━
    /// <summary>
    /// 動作に関する処理を定義したクラス
    /// </summary>
    //━━━━━━━━━━━━━━━━━━━
    public class Move
    {
        //=========================================
        /// <summary>
        ///  ホーム位置に移動させます。
        /// </summary>
        /// <param name="Servos"></param>
        /// <returns></returns>
        //=========================================
        public static bool Home(Actuators Servos)
        {
            foreach (var servo in Servos)
            {
                if (servo.GetType() != typeof(RcServo)) { continue; }
                (servo as RcServo).Home();
            }
            return true;
        }

        //=========================================
        /// <summary>
        /// 左足を上げます。
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool UpLeftFoot(MachineSpec spec, RcServo Left, RcServo Right) 
        {
            // 足首回転
            Left.Rotate(spec.AnkleDegree);
            Right.Rotate(spec.AnkleDegree * 2);
            return true; 
        }

        //=========================================
        /// <summary>
        /// 左足を前に出します。
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool PutLeftFoot(MachineSpec spec, RcServo Left, RcServo Right)
        {
            // ふともも回転
            Right.Rotate(spec.ThighDegree);
            Left.Rotate(spec.ThighDegree);
            return true;
        }

        //=========================================
        /// <summary>
        /// 左足を下に下げます。
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool DownLeftFoot(MachineSpec spec, RcServo Left, RcServo Right)
        {
            // 足首回転
            Left.Rotate(0);
            Right.Rotate(0);
            return true;
        }


        //=========================================
        /// <summary>
        /// 右足を上げます。
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool UpRightFoot(MachineSpec spec, RcServo Left, RcServo Right)
        {
            // 足首回転
            Right.Rotate(-spec.AnkleDegree);
            Left.Rotate(-spec.AnkleDegree * 2);
            return true;
        }

        //=========================================
        /// <summary>
        /// 右足を前に出します。
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool PutRightFoot(MachineSpec spec, RcServo Left, RcServo Right)
        {
            // ふともも回転
            Right.Rotate(-spec.ThighDegree);
            Left.Rotate(-spec.ThighDegree);
            return true;
        }

        //=========================================
        /// <summary>
        /// 右足を下に下げます。
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool DownRightFoot(MachineSpec spec, RcServo Left, RcServo Right)
        {
            // 足首回転
            Right.Rotate(0);
            Left.Rotate(0);
            return true;
        }

        //=========================================
        /// <summary>
        /// 左足を広げます。
        /// </summary>
        /// <returns></returns>
        //=========================================
        public static bool OpenLeftFoot() { return true; }

        //=========================================
        /// <summary>
        /// 左足を閉じます。
        /// </summary>
        /// <returns></returns>
        //=========================================
        public static bool CloseLeftFoot() { return true; }

        //=========================================
        /// <summary>
        /// 右足を広げます。
        /// </summary>
        /// <returns></returns>
        //=========================================
        public static bool OpenRightFoot() { return true; }

        //=========================================
        /// <summary>
        /// 右足を閉じます。
        /// </summary>
        /// <returns></returns>
        //=========================================
        public static bool CloseRightFoot() { return true; }

    }
}
