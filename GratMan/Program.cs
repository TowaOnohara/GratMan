using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace GratMan
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            //testLogic.test_Rotetion(this.extender);
            //testLogic.test_Rotetion2(this.extender);

            //ArrayList servos = new ArrayList();
            //servos.Add(new RcServo(extender, GT.Socket.Pin.Seven)); // RIGHT_THIGH
            //servos.Add(new RcServo(breakout, GT.Socket.Pin.Seven)); // RIGHT_ANKLE
            //servos.Add(new RcServo(extender, GT.Socket.Pin.Eight)); // LEFT_THIGH
            //servos.Add(new RcServo(breakout, GT.Socket.Pin.Eight)); // LEFT_ANKLE

            //// サーボ回転
            ////----------------------
            //foreach (RcServo item in servos)
            //{
            //    item.Home();
            //}

            // ハード情報の設定
            MachineSpec GratmanSpec = new MachineSpec
            {
                AnkleDegree = 20,
                ThighDegree = 20,
            };

            // モータ情報の設定
            Actuators servos = new Actuators(typeof(RcServo));
            servos.Add(new RcServo(extender, GT.Socket.Pin.Seven)); // RIGHT_THIGH
            servos.Add(new RcServo(breakout, GT.Socket.Pin.Seven)); // RIGHT_ANKLE
            servos.Add(new RcServo(extender, GT.Socket.Pin.Eight)); // LEFT_THIGH
            servos.Add(new RcServo(breakout, GT.Socket.Pin.Eight)); // LEFT_ANKLE

            // インストール
            GRobot Gratman = new GRobot();
            Gratman.Install(GratmanSpec, servos);
            
            // ホーミング
            Gratman.Home();

            // 少し待機
            Thread.Sleep(2000);
            
            // Walk
            Gratman.Walk(5);

            // ホーミング
            Gratman.Home();
        }
    }
}
