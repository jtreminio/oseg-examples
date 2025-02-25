require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

upsert_context_kind_payload = LaunchDarklyClient::UpsertContextKindPayload.new
upsert_context_kind_payload.name = "organization"
upsert_context_kind_payload.description = "An example context kind for organizations"
upsert_context_kind_payload.hide_in_targeting = false
upsert_context_kind_payload.archived = false
upsert_context_kind_payload.version = 1

begin
    response = LaunchDarklyClient::ContextsApi.new.put_context_kind(
        nil, # project_key
        nil, # key
        upsert_context_kind_payload,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Contexts#put_context_kind: #{e}"
end
