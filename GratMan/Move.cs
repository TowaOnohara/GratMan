using System;
using System.Collections;
using Microsoft.SPOT;

namespace GratMan
{
    //��������������������������������������
    /// <summary>
    /// ����Ɋւ��鏈�����`�����N���X
    /// </summary>
    //��������������������������������������
    public class Move
    {
        //=========================================
        /// <summary>
        ///  �z�[���ʒu�Ɉړ������܂��B
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
        /// �������グ�܂��B
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool UpLeftFoot(MachineSpec spec, RcServo Left, RcServo Right) 
        {
            // �����]
            Left.Rotate(spec.AnkleDegree);
            Right.Rotate(spec.AnkleDegree * 2);
            return true; 
        }

        //=========================================
        /// <summary>
        /// ������O�ɏo���܂��B
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool PutLeftFoot(MachineSpec spec, RcServo Left, RcServo Right)
        {
            // �ӂƂ�����]
            Right.Rotate(spec.ThighDegree);
            Left.Rotate(spec.ThighDegree);
            return true;
        }

        //=========================================
        /// <summary>
        /// ���������ɉ����܂��B
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool DownLeftFoot(MachineSpec spec, RcServo Left, RcServo Right)
        {
            // �����]
            Left.Rotate(0);
            Right.Rotate(0);
            return true;
        }


        //=========================================
        /// <summary>
        /// �E�����グ�܂��B
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool UpRightFoot(MachineSpec spec, RcServo Left, RcServo Right)
        {
            // �����]
            Right.Rotate(-spec.AnkleDegree);
            Left.Rotate(-spec.AnkleDegree * 2);
            return true;
        }

        //=========================================
        /// <summary>
        /// �E����O�ɏo���܂��B
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool PutRightFoot(MachineSpec spec, RcServo Left, RcServo Right)
        {
            // �ӂƂ�����]
            Right.Rotate(-spec.ThighDegree);
            Left.Rotate(-spec.ThighDegree);
            return true;
        }

        //=========================================
        /// <summary>
        /// �E�������ɉ����܂��B
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        //=========================================
        public static bool DownRightFoot(MachineSpec spec, RcServo Left, RcServo Right)
        {
            // �����]
            Right.Rotate(0);
            Left.Rotate(0);
            return true;
        }

        //=========================================
        /// <summary>
        /// �������L���܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        public static bool OpenLeftFoot() { return true; }

        //=========================================
        /// <summary>
        /// ��������܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        public static bool CloseLeftFoot() { return true; }

        //=========================================
        /// <summary>
        /// �E�����L���܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        public static bool OpenRightFoot() { return true; }

        //=========================================
        /// <summary>
        /// �E������܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        public static bool CloseRightFoot() { return true; }

    }
}
