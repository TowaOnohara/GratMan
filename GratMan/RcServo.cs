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
        /// コンストラクタ 
        /// </summary>
        /// <param name="ServoConector"></param>
        /// <param name="PinNumber"></param>
        /// <param name="Info"></param>
        //==========================================
        public RcServo(Extender ServoConector, GT.Socket.Pin PinNumber, HardwareInfo Info = null) 
        {
            // パラメータ確認
            if ((PinNumber != GT.Socket.Pin.Seven) && 
                (PinNumber != GT.Socket.Pin.Eight) && 
                (PinNumber != GT.Socket.Pin.Nine)) 
            {
                throw new ArgumentException("7,8,9のいずれかを指定する必要があります。","PinNumber");
            }
            // ハード情報の取得
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

            // インスタンス化
            servo = ServoConector.SetupPWMOutput(PinNumber);//must be pin 7,8,9
            servo.Active = true;
        }
        public RcServo(Breakout ServoConector, GT.Socket.Pin PinNumber, HardwareInfo Info = null)
        {
            // パラメータ確認
            if ((PinNumber != GT.Socket.Pin.Seven) &&
                (PinNumber != GT.Socket.Pin.Eight) &&
                (PinNumber != GT.Socket.Pin.Nine))
            {
                throw new ArgumentException("7,8,9のいずれかを指定する必要があります。", "PinNumber");
            }
            // ハード情報の取得
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

            // インスタンス化
            servo = ServoConector.SetupPWMOutput(PinNumber);//must be pin 7,8,9
            servo.Active = true;
        }

        //==============================
        /// <summary>
        /// 指定角度への回転
        /// </summary>
        /// <param name="degree"></param>
        //==============================
        public void Rotate(int degree) 
        {
            uint hightime = ConvertToInterval(degree);
            servo.SetPulse(hwInfo.PriodFrequency_ns, hightime * 1000);      // パルス幅の変更
            tagetPosition = degree;
        }

        //==============================
        /// <summary>
        /// 原点へ移動
        /// </summary>
        //==============================
        public void Home() 
        {
            Rotate(0);
        }
        	
	    // 現在目標位置の取得
        private double GetTagetPosition()
        {
            return this.tagetPosition;
        }

        //==============================
        /// <summary>
        /// 指定角度に応じた周波数を取得
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
        /// 指定角度が範囲害である場合、最大値または最小値に
        /// 調整します。
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
        /// 対象となるRCサーボの物理的特性を定義します。
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
