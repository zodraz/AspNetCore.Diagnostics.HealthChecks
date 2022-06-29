using Amazon;
using Amazon.Runtime;

namespace HealthChecks.Aws.Sns;

/// <summary>
/// Options for <see cref="SnsTopicAndSubscriptionHealthCheck"/>.
/// </summary>
public class SnsOptions
{
    public AWSCredentials? Credentials { get; set; }

    public RegionEndpoint? RegionEndpoint { get; set; }

    internal HashSet<string> Topics { get; } = new HashSet<string>();

    internal Dictionary<string, string[]> TopicsAndSubscriptions { get; } = new Dictionary<string, string[]>();


    /// <summary>
    /// Add an AWS SNS topic and its optional subscriptions to be checked
    /// </summary>
    /// <param name="topicName">The topic to be checked</param>
    /// <param name="subscriptions">The subscription ARNs from the  <paramref name="topicName"/> to be checked</param>
    /// <returns>Reference to the same <see cref="SnsOptions"/> to allow further configuration.</returns>
    public SnsOptions AddTopicAndSubscriptions(string topicName, string[]? subscriptions = null)
    {
        if (subscriptions is not null)
        {
            TopicsAndSubscriptions.Add(topicName, subscriptions);
        }
        else
        {
            Topics.Add(topicName);
        }

        return this;
    }
}
