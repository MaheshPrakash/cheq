#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Linq;
using System.Xml.Linq;
using Dev2.Common;
using Dev2.Common.Interfaces.Core.Graph;
using Newtonsoft.Json.Linq;
using Unlimited.Framework.Converters.Graph.Poco;
using Unlimited.Framework.Converters.Graph.String.Json;
using Unlimited.Framework.Converters.Graph.String.Xml;



namespace Unlimited.Framework.Converters.Graph.String

{
    [Serializable]
    public class StringInterrogator : IInterrogator
    {
        #region Methods

        public IMapper CreateMapper(object data)
        {
            IMapper mapper;

            if (IsXml(data.ToString()))
            {
                mapper = new XmlMapper();
            }
            else if (IsJson(data.ToString()))
            {
                mapper = new JsonMapper();
            }
            else
            {
                if(data.GetType().IsPrimitive)
                {
                    mapper = new PocoMapper();
                }
                else
                {
                    mapper = new StringMapper();
                }
            }
            return mapper;
        }

        public INavigator CreateNavigator(object data, Type pathType)
        {
            if (!pathType.GetInterfaces().Contains(typeof (IPath)))
            {
                throw new Exception("'" + pathType + "' doesn't implement '" + typeof (IPath) + "'");
            }

            INavigator navigator;

            if (pathType == typeof (XmlPath))
            {
                navigator = new XmlNavigator(data);
            }
            else if (pathType == typeof (JsonPath))
            {
                navigator = new JsonNavigator(data);
            }
            else if (pathType == typeof (PocoPath))
            {
                navigator = new PocoNavigator(data);
            }
            else
            {
                navigator = null;
            }

            return navigator;
        }

        #endregion Methods

        #region Private Methods

        bool IsXml(string data)
        {
            var result = true;

            try
            {

                XDocument.Parse(data);

            }
            catch (Exception ex)
            {
                Dev2Logger.Error(ex, GlobalConstants.WarewolfError);
                result = false;
            }

            return result;
        }

        bool IsJson(string data)
        {
            var result = true;

            try
            {
                JToken.Parse(data);
            }
            catch (Exception ex)
            {
                Dev2Logger.Error(ex, GlobalConstants.WarewolfError);
                result = false;
            }

            return result;
        }

        #endregion Private Methods
    }
}