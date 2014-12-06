using System;
using System.Threading;
using System.Collections;
using Microsoft.SPOT;

namespace GratMan
{
    //����������������������������������������������
    /// <summary>
    /// GRobot�N���X
    /// </summary>
    //����������������������������������������������
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
        /// �R���X�g���N�^
        /// </summary>
        //=========================================
        public GRobot() 
        {
        }

        //=========================================
        /// <summary>
        /// �n�[�h�E�F�A���̃C���X�g�[��
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
        /// �z�[���|�W�V�����ֈړ�
        /// </summary>
        //=========================================
        public void Home() 
        {
            Move.Home(this.ServoMotors);
        }

        //=========================================
        /// <summary>
        /// �����Ԃ̎擾
        /// </summary>
        /// <returns></returns>
        //=========================================
        public MoveState GetState() { return this.State; }

        //=========================================
        /// <summary>
        /// �w����������s���܂��B
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
        /// 1�Z�b�g���s���܂��B
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
        /// ���s���J�n���܂��B
        /// StopWalk���R�[�������܂ŕ��s���p�����܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        public bool StartWalk() 
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// ���s���~���܂��B
        /// StartWalk�R�[���ɂ���ĊJ�n���������s�̒�~�����ł��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        public bool StopWalk() 
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// �w��������o�b�N���܂��B
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
        /// �w�苗�����������s���܂��B
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
        /// �������E�֌����܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        public bool TurnRight() 
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// ���������֌����܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        public bool TurnLeft()
        {
            return true;
        }

        //=========================================
        /// <summary>
        /// �w��p�x��������ς��܂��B
        /// �����v���𐳂̕����Ƃ��܂��B
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
        /// �~�ʂ�`���Ȃ�����s���܂��B
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
        /// ����������O�ɏo���܂��B
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
        /// �E��������O�ɏo���܂��B
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
        /// �������L���܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        protected bool Turn_OpenLeftSide() { return true; }

        //=========================================
        /// <summary>
        /// �E�����L���܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        protected bool Turn_OpenRightSide() { return true; }

        //=========================================
        /// <summary>
        /// ��������܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        protected bool Turn_CloseLeftSide() { return true; }

        //=========================================
        /// <summary>
        /// �E������܂��B
        /// </summary>
        /// <returns></returns>
        //=========================================
        protected bool Turn_CloseRightSide() { return true; }


    }

    //����������������������������������������������
    /// <summary>
    /// ��]�����񋓑�
    /// </summary>
    //����������������������������������������������
    public enum Circular 
    {
        Right,
        Left,
    }

    //����������������������������������������������
    /// <summary>
    /// �����Ԃ�\���񋓑�
    /// </summary>
    //����������������������������������������������
    public enum MoveState 
    {
        Indefinite,         // �s����
        Home,               // �z�[���|�W�V����
        Walking,            // ���s��
    }

    //����������������������������������������������
    /// <summary>
    /// �@�B�{�̂̕����I�f�[�^
    /// </summary>
    //����������������������������������������������
    public class MachineSpec 
    {
        /// <summary>
        /// �������]������p�x
        /// </summary>
        public int AnkleDegree { get; set; }    

        /// <summary>
        /// ����������]������p�x
        /// </summary>
        public int ThighDegree { get; set; }
    }

    //����������������������������������������������
    /// <summary>
    /// ����@�\�N���X
    /// </summary>
    //����������������������������������������������
    public class Actuators : ArrayList
    {
        private Type MemberType;
        public Actuators(Type type) 
        {
            MemberType = type;
        }

        //=========================================
        /// <summary>
        /// �^�̊m�F
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
