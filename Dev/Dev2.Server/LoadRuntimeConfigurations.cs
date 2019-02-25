﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common;
using Dev2.Diagnostics.Logging;
using Dev2.Runtime.Configuration;
using System;

namespace Dev2
{
    public class LoadRuntimeConfigurations
    {
        private readonly IWriter _writer;
        ISettingsProvider _settingsProvider;

        public LoadRuntimeConfigurations(IWriter writer) 
            :this(writer, null)
        {
            
        }

        public LoadRuntimeConfigurations(IWriter writer, ISettingsProvider settingsProvider)
        {
            _writer = writer;
            _settingsProvider = settingsProvider;
        }

        void LoadSettingsProvider()
        {
            _writer.Write("Loading settings provider...  ");
            if (EnvironmentVariables.WebServerUri != null)
            {
                Runtime.Configuration.SettingsProvider.WebServerUri = EnvironmentVariables.WebServerUri;
                _writer.WriteLine("done.");
            }
            else
            {
                _writer.Write("fail.");
            }
        }

        void ConfigureLoggging()
        {
            try
            {
                _writer.Write("Configure logging...  ");
                if (_settingsProvider is null)
                {
                    _settingsProvider = Runtime.Configuration.SettingsProvider.Instance;
                }
                var settings = _settingsProvider.Configuration;
                WorkflowLogger.LoggingSettings = settings.Logging;

                _writer.WriteLine("done.");
            }
            catch (Exception e)
            {
                _writer.Write("fail.");
                _writer.WriteLine(e.Message);
            }
        }

        public void Execute()
        {
            LoadSettingsProvider();
            ConfigureLoggging();
        }
    }
}
