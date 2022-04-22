namespace IHM_ESP
{
    class MotorStateMessage : Message
    {
        public override byte code => 99;
    }

    class StartMessage : Message
    {
        public override byte code => 19;
    }

    #region Setters  // Ok

    class SetPwmMessage : Message // Ok
    {
        public override byte code => 01;
    }
    class SetRpmMessage : Message // Ok
    {
        public override byte code => 03;
    }
    class SetMaxPwmMessage : Message // Ok
    {
        public override byte code => 08;
    }
    class SetMinPwmMessage : Message // Ok
    {
        public override byte code => 11;
    }
    class SetMaxCurrentMessage : Message // Ok
    {
        public override byte code => 05;
    }
    class SetPMessage : Message // Ok
    {
        public override byte code => 16;
    }
    class SetIMessage : Message // Ok
    {
        public override byte code => 17;
    }
    class SetDMessage : Message // Ok
    {
        public override byte code => 18;
    }
    #endregion

    #region Getters // Ok
    class GetPwmMessage : Message // Ok
    {
        public override byte code => 02;
    }
    class GetRpmMessage : Message // Ok
    {
        public override byte code => 04;
    }
    class GetMaxCurrentMessage : Message // Ok
    {
        public override byte code => 06;
    }
    class GetCurrentMessage : Message // Ok
    {
        public override byte code => 07;
    }
    class GetMaxPwmMessage : Message // Ok
    {
        public override byte code => 10;
    }
    class GetMinPwmMessage : Message // Ok
    {
        public override byte code => 12;
    }
    class GetPMessage : Message // Ok
    {
        public override byte code => 13;
    }
    class GetIMessage : Message // Ok
    {
        public override byte code => 14;
    }
    class GetDMessage : Message // Ok
    {
        public override byte code => 15;
    }

    #endregion
}
