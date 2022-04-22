namespace IHM_ESP
{
    public abstract class IComm
    {
        public abstract void SetPWM(double duty);

        public abstract void SetPWM(int duty);

        public abstract void SetRPM(int rpm);

        public abstract void SetMaxPwm(int duty);

        public abstract void SetMaxPwm(double duty);

        public abstract void SetMinPwm(int duty);

        public abstract void SetMinPwm(double duty);

        public abstract void SetMaxCurrent(double current);

        public abstract void SetP(double p);

        public abstract void SetI(double i);

        public abstract void SetD(double d);

        public abstract double GetPWMDuty();

        public abstract int GetRPM();

        public abstract double GetMaxCurrent();

        public abstract double GetCurrent();

        public abstract double GetMaxPwm();

        public abstract double GetMinPwm();

        public abstract double GetP();

        public abstract double GetI();

        public abstract double GetD();


        public abstract void Start();//Implementar mensagem

        public abstract void Stop();
    }
}
