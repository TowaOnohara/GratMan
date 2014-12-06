using System;
using Microsoft.SPOT;
using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace GratMan
{
    public class RcServo
    {
        private HardwareInfo hwInfo = null;
        private GT.Interfaces.PWMOutput servo;
        private int tagetPosition;

        //==========================================
        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        /// <param name="ServoConector"></param>
        /// <param name="PinNumber"></param>
        /// <param name="Info"></param>
        //==========================================
        public RcServo(Extender ServoConector, GT.Socket.Pin PinNumber, HardwareInfo Info = null) 
        {
            // �p�����[�^�m�F
            if ((PinNumber != GT.Socket.Pin.Seven) && 
                (PinNumber != GT.Socket.Pin.Eight) && 
                (PinNumber != GT.Socket.Pin.Nine)) 
            {
                throw new ArgumentException("7,8,9�̂����ꂩ���w�肷��K�v������܂��B","PinNumber");
            }
            // �n�[�h���̎擾
            if (Info == null) 
            {
                hwInfo = new HardwareInfo
                {
                    PriodFrequency_ns = 20 * 1000 * 1000,
                    ConvertFactor = 7.778,
                    ConvertOffset = 1300,
                    MaxDegree = 80,
                    MinDegree = -80,
                };
            }
            else 
            {
                hwInfo = Info;
            }

            // �C���X�^���X��
            servo = ServoConector.SetupPWMOutput(PinNumber);//must be pin 7,8,9
            servo.Active = true;
        }
        public RcServo(Breakout ServoConector, GT.Socket.Pin PinNumber, HardwareInfo Info = null)
        {
            // �p�����[�^�m�F
            if ((PinNumber != GT.Socket.Pin.Seven) &&
                (PinNumber != GT.Socket.Pin.Eight) &&
                (PinNumber != GT.Socket.Pin.Nine))
            {
                throw new ArgumentException("7,8,9�̂����ꂩ���w�肷��K�v������܂��B", "PinNumber");
            }
            // �n�[�h���̎擾
            if (Info == null)
            {
                hwInfo = new HardwareInfo
                {
                    PriodFrequency_ns = 20 * 1000 * 1000,
                    ConvertFactor = 7.778,
                    ConvertOffset = 1300,
                    MaxDegree = 80,
                    MinDegree = -80,
                };
            }
            else
            {
                hwInfo = Info;
            }

            // �C���X�^���X��
            servo = ServoConector.SetupPWMOutput(PinNumber);//must be pin 7,8,9
            servo.Active = true;
        }

        //==============================
        /// <summary>
        /// �w��p�x�ւ̉�]
        /// </summary>
        /// <param name="degree"></param>
        //==============================
        public void Rotate(int degree) 
        {
            uint hightime = ConvertToInterval(degree);
            servo.SetPulse(hwInfo.PriodFrequency_ns, hightime * 1000);      // �p���X���̕ύX
            tagetPosition = degree;
        }

        //==============================
        /// <summary>
        /// ���_�ֈړ�
        /// </summary>
        //==============================
        public void Home() 
        {
            Rotate(0);
        }
        	
	    // ���ݖڕW�ʒu�̎擾
        private double GetTagetPosition()
        {
            return this.tagetPosition;
        }

        //==============================
        /// <summary>
        /// �w��p�x�ɉ��������g�����擾
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        //==============================
        private uint ConvertToInterval(int degree) 
        {
            return (uint)(hwInfo.ConvertFactor * AjustDegree(degree) + hwInfo.ConvertOffset);
        }

        //==============================
        /// <summary>
        /// �w��p�x���͈͊Q�ł���ꍇ�A�ő�l�܂��͍ŏ��l��
        /// �������܂��B
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        //==============================
        private int AjustDegree(int degree) 
        {
            if (hwInfo.MaxDegree < degree) { return hwInfo.MaxDegree; }
            if (hwInfo.MinDegree > degree) { return hwInfo.MinDegree; }
            return degree;
        }

        //==============================
        /// <summary>
        /// �ΏۂƂȂ�RC�T�[�{�̕����I�������`���܂��B
        /// </summary>
        //==============================
        public class HardwareInfo
        {
            public uint PriodFrequency_ns { get; set; }
            public double ConvertFactor { get; set; }
            public double ConvertOffset { get; set; }
            public int MaxDegree { get; set; }
            public int MinDegree { get; set; }
        }
    }
}
