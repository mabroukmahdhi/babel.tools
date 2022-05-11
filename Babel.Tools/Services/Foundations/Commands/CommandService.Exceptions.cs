//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************

using Babel.Tools.Models.Commands;
using Babel.Tools.Models.Commands.Exceptions;
using System;

namespace Babel.Tools.Services.Foundations.Commands
{
    public partial class CommandService
    {
        private delegate IBabelCommand ReturningCommandFunction();
        private delegate void ExecuteCommandFunction();

        private IBabelCommand TryCatch(ReturningCommandFunction returningCommand)
        {
            try
            {
                return returningCommand();
            }
            catch (ArgumentNullException ex)
            {
                throw CreateValidationExcetion(ex);
            }
            catch (ArgumentException ex)
            {
                throw CreateValidationExcetion(ex);
            }
            catch (NotFoundCommandException ex)
            {
                throw new CommandValidationException(ex);
            }
            catch (Exception ex)
            {
                throw new CommandServiceException(ex);
            }
        }

        private void TryCatch(ExecuteCommandFunction execute)
        {
            try
            {
                execute();
            }
            catch (Exception ex)
            {
                throw new CommandServiceException(ex);
            }
        }

        private Exception CreateValidationExcetion(Exception ex)
        {
            var invalidCmdException = new InvalidCommandException();

            invalidCmdException.UpsertDataList(ex.Source, ex.Message);

            return new CommandValidationException(invalidCmdException);
        }
    }
}
