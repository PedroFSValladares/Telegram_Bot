﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.BOT.Application.Boundaries.Marc;
using Telegram.BOT.Domain.Enums;
using Telegram.BOT.Domain.Logs;

namespace Telegram.BOT.Application.UseCases.Marc.DeleteMarc;

public class DeleteMarcRequest : Output<DeleteMarcOutput>
{
    public required Guid Id { get; init; }
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(Log.AddLog(type, message, "Delete Marc"));
}
