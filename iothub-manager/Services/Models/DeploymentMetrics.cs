// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using Microsoft.Azure.Devices;

namespace Microsoft.Azure.IoTSolutions.IotHubManager.Services.Models
{
    /// <summary>
    /// Statistics exposed by configuration queries
    /// </summary>
    public class DeploymentMetrics
    {
        public IDictionary<string, long> Metrics { get; set; }
        public IDictionary<string, DeploymentStatus> DeviceStatuses { get; set; }

        public DeploymentMetrics(ConfigurationMetrics systemMetrics, ConfigurationMetrics customMetrics)
        {
            this.Metrics = new Dictionary<string, long>();
            this.DeviceStatuses = new Dictionary<string, DeploymentStatus>();

            if (systemMetrics?.Results?.Count > 0)
            {
                foreach (var pair in systemMetrics.Results)
                {
                    this.Metrics.Add(pair);
                }
            }

            if (customMetrics?.Results?.Count > 0)
            {
                foreach (var pair in customMetrics.Results)
                {
                    this.Metrics.Add(pair);
                }
            }
        }
    }
}
