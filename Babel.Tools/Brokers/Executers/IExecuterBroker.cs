//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Babel.Tools.Models.Commands;
using Babel.Tools.Models.Outputs;

namespace Babel.Tools.Brokers.Executers
{
    public interface IExecuterBroker
    {
        OutputCollection Execute(IBabelCommand command);
    }
}
