﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Serilog;
using SimpleBank.Core.Commands;
using SimpleBank.Core.Models;
using SimpleBank.Core.Services;
using SimpleBank.Core.Utils;
using SimpleBank.Data;
using Entity = SimpleBank.Data.Models;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace SimpleBank.ConsoleApp
{
    public class Application : IHostedService
    {
        private readonly IOperationService _operationService;

        public Application(IOperationService operationService)
        {
            _operationService = operationService;
        }

        private OperationCommand CreateCommand(string command)
        {
            OperationCommand operationCommand;
            if (command == "d")
                operationCommand = new WithdrawByAccountId();
            else if (command == "c")
                operationCommand = new DepositByAccountId();
            else
                throw new ArgumentOutOfRangeException(nameof(command));

            operationCommand.HappenedAt = DateTime.ParseExact(ReadLine("HappenedAt: "), "yyyy/mm/dd", CultureInfo.InvariantCulture);
            operationCommand.AccountId = int.Parse(ReadLine("AccountId: "));
            operationCommand.Currency = Enum.Parse<CurrencyCode>(ReadLine("Currency: "));
            operationCommand.Amount = decimal.Parse(ReadLine("Amount: "));

            return operationCommand;
        }

        private static string ReadLine(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("For Debit Operation enter - [d]");
                    Console.WriteLine("For Credit Operation enter - [c]");
                    var command = Console.ReadLine();

                    switch (CreateCommand(command))
                    {
                        case WithdrawByAccountId debitByAccountId:
                            await _operationService.WithdrawAsync(debitByAccountId);
                            break;

                        case DepositByAccountId creditByAccountId:
                            await _operationService.Deposit(creditByAccountId);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error in SimpleBank.ConsoleApp");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Application Stopped");
            return Task.CompletedTask;
        }
    }
}