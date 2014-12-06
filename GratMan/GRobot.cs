using System;
using System.Threading;
using System.Collections;
using Microsoft.SPOT;

namespace GratMan
{
    //━━━━━━━━━━━━━━━━━━━━━━━
    /// <summary>
    /// GRobotクラス
    /// </summary>
    //━━━━━━━━━━━━━━━━━━━━━━━
    public class GRobot
    {
        public static readonly int RIGHT_THIGH = 0;
        public static readonly int RIGHT_ANKLE = 1;
        public static readonly int LEFT_THIGH = 2;
        public static readonly int LEFT_ANKLE = 3;
        protected MachineSpec Machine = null;
        protected Actuators ServoMotors = null;
        private MoveState State = MoveState.Indefinite;

        //=========================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        //=========================================
        public GRobot() 
        {
        }

        //=========================================
        /// <summary>
        /// ハードウェア情報のインストール
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="sevo"></param>
        /// <returns></returns>
        //=========================================
        public bool Install(MachineSpec spec, Actuators sevo) 
        {
            Machine = spec;
            ServoMotors = sevo;
            return true;
        }

        //=========================================
        /// <summary>
        /// ホームポジションへ移動
        /// </summary>
        //=========================================
        public void Home() 
        {
            Move.Home(this.ServoMotors);
        }

        //=========================================
        /// <summary>
        /// 動作状態の取得
        /// </summary>
        /// <returns></returns>
        //=========================================
        public MoveState GetState() { return this.State; }

        //=========================================
        /// <summary>
        /// 指定歩数分歩行します。
        /// </summary>
        /// <param name="walkCount"></param>
        /// <returns></returns>
        //=========================================
        public bool Walk(int walkCount) 
        {
            for (int i = 0; i < walkCount; i++) 
            {
                Walk();
            }
            return true;
        }
        //=========================================
        /// <summary>
        /// 1セット歩行します。
        /// </summary>
        /// <returns></returns>
        //=========================================
        public bool Walk()
        {
            Walk_PutLeftFoot();
            Walk_PutRightFoot();
            return true;
        }
        //=========================================
        /// <summary>
        /// 歩行を開始します。
        /// StopWalkがコールされるまで歩行を継続します。
        /// </summary>
        /// <returns></returns>
        //=========================================
        public bool StartWalk() 
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// 歩行を停止します。
        /// StartWalkコールによって開始さえた歩行の停止処理です。
        /// </summary>
        /// <returns></returns>
        //=========================================
        public bool StopWalk() 
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// 指定歩数分バックします。
        /// </summary>
        /// <param name="walkCount"></param>
        /// <returns></returns>
        //=========================================
        public bool WalkBack(int walkCount) 
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// 指定距離分だけ歩行します。
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        //=========================================
        public bool WalkDistance(int distance) 
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// 方向を右へ向けます。
        /// </summary>
        /// <returns></returns>
        //=========================================
        public bool TurnRight() 
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// 方向を左へ向けます。
        /// </summary>
        /// <returns></returns>
        //=========================================
        public bool TurnLeft()
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// 指定角度分方向を変えます。
        /// 反時計回りを正の方向とします。
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        //=========================================
        public bool Turn(int degree) 
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// 円弧を描きながら歩行します。
        /// </summary>
        /// <param name="Direction"></param>
        /// <param name="Radius"></param>
        /// <param name="WalkCount"></param>
        /// <returns></returns>
        //=========================================
        public bool CircularWalk(Circular Direction, int Radius, int WalkCount)
        {
            return true;
        }


        //---------------------



        //=========================================
        /// <summary>
        /// 左足を一歩前に出します。
        /// </summary>
        /// <returns></returns>
        //=========================================
        protected bool Walk_PutLeftFoot()
        {
            Move.UpLeftFoot(this.Machine, this.ServoMotors[GRobot.LEFT_ANKLE] as RcServo, this.ServoMotors[GRobot.RIGHT_ANKLE] as RcServo);
            Thread.Sleep(200);
            Move.PutLeftFoot(this.Machine, this.ServoMotors[GRobot.LEFT_THIGH] as RcServo, this.ServoMotors[GRobot.RIGHT_THIGH] as RcServo);
            Thread.Sleep(200);           
            Move.DownLeftFoot(this.Machine, this.ServoMotors[GRobot.LEFT_ANKLE] as RcServo, this.ServoMotors[GRobot.RIGHT_ANKLE] as RcServo);
            Thread.Sleep(200);
            return true;
        }

        //=========================================
        /// <summary>
        /// 右足を一歩前に出します。
        /// </summary>
        /// <returns></returns>
        //=========================================
        protected bool Walk_PutRightFoot()
        {
            Move.UpRightFoot(this.Machine, this.ServoMotors[GRobot.LEFT_ANKLE] as RcServo, this.ServoMotors[GRobot.RIGHT_ANKLE] as RcServo);
            Thread.Sleep(200);
            Move.PutRightFoot(this.Machine, this.ServoMotors[GRobot.LEFT_THIGH] as RcServo, this.ServoMotors[GRobot.RIGHT_THIGH] as RcServo);
            Thread.Sleep(200);
            Move.DownRightFoot(this.Machine, this.ServoMotors[GRobot.LEFT_ANKLE] as RcServo, this.ServoMotors[GRobot.RIGHT_ANKLE] as RcServo);
            Thread.Sleep(200);
            return true;
        }

        //=========================================
        /// <summary>
        /// 左足を広げます。
        /// </summary>
        /// <returns></returns>
        //=========================================
        protected bool Turn_OpenLeftSide() { return true; }

        //=========================================
        /// <summary>
        /// 右足を広げます。
        /// </summary>
        /// <returns></returns>
        //=========================================
        protected bool Turn_OpenRightSide() { return true; }

        //=========================================
        /// <summary>
        /// 左足を閉じます。
        /// </summary>
        /// <returns></returns>
        //=========================================
        protected bool Turn_CloseLeftSide() { return true; }

        //=========================================
        /// <summary>
        /// 右足を閉じます。
        /// </summary>
        /// <returns></returns>
        //=========================================
        protected bool Turn_CloseRightSide() { return true; }


    }

    //━━━━━━━━━━━━━━━━━━━━━━━
    /// <summary>
    /// 回転方向列挙体
    /// </summary>
    //━━━━━━━━━━━━━━━━━━━━━━━
    public enum Circular 
    {
        Right,
        Left,
    }

    //━━━━━━━━━━━━━━━━━━━━━━━
    /// <summary>
    /// 動作状態を表す列挙体
    /// </summary>
    //━━━━━━━━━━━━━━━━━━━━━━━
    public enum MoveState 
    {
        Indefinite,         // 不定状態
        Home,               // ホームポジション
        Walking,            // 歩行中
    }

    //━━━━━━━━━━━━━━━━━━━━━━━
    /// <summary>
    /// 機械本体の物理的データ
    /// </summary>
    //━━━━━━━━━━━━━━━━━━━━━━━
    public class MachineSpec 
    {
        /// <summary>
        /// 足首を回転させる角度
        /// </summary>
        public int AnkleDegree { get; set; }    

        /// <summary>
        /// 太ももを回転させる角度
        /// </summary>
        public int ThighDegree { get; set; }
    }

    //━━━━━━━━━━━━━━━━━━━━━━━
    /// <summary>
    /// 動作機構クラス
    /// </summary>
    //━━━━━━━━━━━━━━━━━━━━━━━
    public class Actuators : ArrayList
    {
        private Type MemberType;
        public Actuators(Type type) 
        {
            MemberType = type;
        }

        //=========================================
        /// <summary>
        /// 型の確認
        /// </summary>
        /// <returns></returns>
        //=========================================
        public bool Check()
        {
            foreach (var item in this)
            {
                if(item.GetType() != this.MemberType)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
