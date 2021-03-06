﻿using System;
using Dotnet.Script.DependencyModel.Logging;
using Dotnet.Script.DependencyModel.Process;

namespace Dotnet.Script.DependencyModel.Context
{
    public class DotnetRestorer : IRestorer
    {
        private readonly CommandRunner _commandRunner;
        private readonly Logger _logger;

        public DotnetRestorer(CommandRunner commandRunner, LogFactory logFactory)
        {
            _commandRunner = commandRunner;
            _logger = logFactory.CreateLogger<DotnetRestorer>();
        }

        public void Restore(string pathToProjectFile)
        {
            _logger.Debug($"Restoring {pathToProjectFile} using the dotnet cli.");            
            _commandRunner.Execute("dotnet", $"restore \"{pathToProjectFile}\"");            
        }

        public bool CanRestore => _commandRunner.Execute("dotnet", "--version") == 0;
    }
}