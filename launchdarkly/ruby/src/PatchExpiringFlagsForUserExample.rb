require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

instructions_1 = LaunchDarklyClient::InstructionUserRequest.new
instructions_1.kind = "addExpireUserTargetDate"
instructions_1.flag_key = "sample-flag-key"
instructions_1.variation_id = "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d"
instructions_1.value = 16534692
instructions_1.version = 1

instructions = [
    instructions_1,
]

patch_users_request = LaunchDarklyClient::PatchUsersRequest.new
patch_users_request.comment = "optional comment"
patch_users_request.instructions = instructions

begin
    response = LaunchDarklyClient::UserSettingsApi.new.patch_expiring_flags_for_user(
        "the-project-key", # project_key
        "the-user-key", # user_key
        "the-environment-key", # environment_key
        patch_users_request,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling UserSettings#patch_expiring_flags_for_user: #{e}"
end
