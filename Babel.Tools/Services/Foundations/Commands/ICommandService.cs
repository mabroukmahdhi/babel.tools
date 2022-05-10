//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************

using Babel.Tools.Models.Commands;

namespace Babel.Tools.Services.Foundations.Commands
{
    public interface ICommandService
    {
        IBabelCommand BuildCommand(object[] args);
        void Execute(object[] args);
    }
}
