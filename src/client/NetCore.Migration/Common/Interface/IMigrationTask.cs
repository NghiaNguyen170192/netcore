﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Migration.Common.Interface;

public interface IMigrationTask
{
    IEnumerable<Type> Dependencies { get; }
    Task ExecuteAsync(Command command);
}