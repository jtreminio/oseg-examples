require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

flag_import_configuration_post = LaunchDarklyClient::FlagImportConfigurationPost.new
flag_import_configuration_post.config = JSON.parse(<<-EOD
    {
        "environmentId": "The ID of the environment in the external system",
        "ldApiKey": "An API key with create flag permissions in your LaunchDarkly account",
        "ldMaintainer": "The ID of the member who will be the maintainer of the imported flags",
        "ldTag": "A tag to apply to all flags imported to LaunchDarkly",
        "splitTag": "If provided, imports only the flags from the external system with this tag. Leave blank to import all flags.",
        "workspaceApiKey": "An API key with read permissions in the external feature management system",
        "workspaceId": "The ID of the workspace in the external system"
    }
    EOD
)
flag_import_configuration_post.name = "Sample configuration"
flag_import_configuration_post.tags = [
    "example-tag",
]

begin
    response = LaunchDarklyClient::FlagImportConfigurationsBetaApi.new.create_flag_import_configuration(
        "projectKey_string", # project_key
        "integrationKey_string", # integration_key
        flag_import_configuration_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagImportConfigurationsBetaApi#create_flag_import_configuration: #{e}"
end
