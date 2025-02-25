require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AuditLogApi.new.get_audit_log_entries

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AuditLog#get_audit_log_entries: #{e}"
end
