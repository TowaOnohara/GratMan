//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.34014
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GratMan {
    using Gadgeteer;
    using GTM = Gadgeteer.Modules;
    
    
    public partial class Program : Gadgeteer.Program {
        
        /// <summary>The UC Battery 4xAA module using socket 8 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.UC_Battery_4xAA uc_battery_4xAA;
        
        /// <summary>The Extender module using socket 4 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.Extender extender;
        
        /// <summary>The Breakout module using socket 3 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.Breakout breakout;
        
        /// <summary>This property provides access to the Mainboard API. This is normally not necessary for an end user program.</summary>
        protected new static GHIElectronics.Gadgeteer.FEZCerberus Mainboard {
            get {
                return ((GHIElectronics.Gadgeteer.FEZCerberus)(Gadgeteer.Program.Mainboard));
            }
            set {
                Gadgeteer.Program.Mainboard = value;
            }
        }
        
        /// <summary>This method runs automatically when the device is powered, and calls ProgramStarted.</summary>
        public static void Main() {
            // Important to initialize the Mainboard first
            Program.Mainboard = new GHIElectronics.Gadgeteer.FEZCerberus();
            Program p = new Program();
            p.InitializeModules();
            p.ProgramStarted();
            // Starts Dispatcher
            p.Run();
        }
        
        private void InitializeModules() {
            this.uc_battery_4xAA = new GTM.GHIElectronics.UC_Battery_4xAA(8);
            this.extender = new GTM.GHIElectronics.Extender(4);
            this.breakout = new GTM.GHIElectronics.Breakout(3);
        }
    }
}