using System;
using System.Threading;
using System.Collections;
using Microsoft.SPOT;
using GT = Gadgeteer;

namespace GratMan
{
    public class testLogic
    {
        public testLogic() 
        {

        }

        public static void test_Rotetion(Gadgeteer.Modules.GHIElectronics.Extender extender) 
        {
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            ArrayList servos = new ArrayList();
            servos.Add(new RcServo(extender, GT.Socket.Pin.Seven));
            servos.Add(new RcServo(extender, GT.Socket.Pin.Eight));
            servos.Add(new RcServo(extender, GT.Socket.Pin.Nine));

            // �T�[�{��]
            //----------------------
            (servos[0] as RcServo).Home();
            (servos[1] as RcServo).Home();

            int i = 0;
            while (i++ <= 5)
            {
                // -60��~60�� �͈̔͂ŉ�]�����܂��B
                for (int degree = -60; degree < 60; degree += 10)
                {
                    (servos[0] as RcServo).Rotate(degree);
                    System.Threading.Thread.Sleep(100);
                }
                for (int degree = 60; degree > -60; degree -= 10)
                {
                    (servos[0] as RcServo).Rotate(degree);
                    System.Threading.Thread.Sleep(100);
                }
                // -60��~60�� �͈̔͂ŉ�]�����܂��B
                for (int degree = -60; degree < 60; degree += 10)
                {
                    (servos[1] as RcServo).Rotate(degree);
                    System.Threading.Thread.Sleep(100);
                }
                for (int degree = 60; degree > -60; degree -= 10)
                {
                    (servos[1] as RcServo).Rotate(degree);
                    System.Threading.Thread.Sleep(100);
                }
            }
        }


        public static void test_Rotetion2(Gadgeteer.Modules.GHIElectronics.Extender extender)
        {
            ArrayList servos = new ArrayList();
            servos.Add(new RcServo(extender, GT.Socket.Pin.Seven));
            servos.Add(new RcServo(extender, GT.Socket.Pin.Eight));

            // �T�[�{��]
            //----------------------
            (servos[0] as RcServo).Home();
            (servos[1] as RcServo).Home();

            while (true)
            {
                // 60����]
                (servos[0] as RcServo).Rotate(60);
                (servos[1] as RcServo).Rotate(60);

                // �ҋ@
                Thread.Sleep(1000);

                // 60����]
                (servos[0] as RcServo).Rotate(-60);
                (servos[1] as RcServo).Rotate(-60);

                // �ҋ@
                Thread.Sleep(1000);
            }
        }

    }
}
